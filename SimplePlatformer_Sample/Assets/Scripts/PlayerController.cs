using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Serialized fields are visible in the inspector
    [SerializeField] private float moveForce = 20;
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private float maxVelocity = 5;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D _rb; // Rigidbody2D component of this object
    private float _moveDirection; // Movement direction of this object
    private Animator _animator; // Animator component of this object

    private float _finalJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D and Collider2D components of this object
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _moveDirection = Input.GetAxisRaw("Horizontal"); // get the movement direction from the input

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) // check if the player is grounded when the jump key is pressed
        {
            _finalJumpForce = jumpForce; // register the jump force for the next FixedUpdate
        }
    }

    // FixedUpdate calls a fixed number of times per second independent from framerate
    // FixedUpdate is called after Update
    void FixedUpdate()
    {
        _rb.AddForce(new Vector2(moveForce * _moveDirection, 0), ForceMode2D.Force); // move the player by applying the force
        _rb.AddForce(new Vector2(0, _finalJumpForce), ForceMode2D.Impulse); // apply the jump force as impulse

        string animState;
        if (Mathf.Abs(_moveDirection) <= 1e-10)
        { // If the player is not moving, stop the player
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            animState = "IsIdle";
        }
        else
        { // if player is moving, limit the velocity of the player
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -maxVelocity, maxVelocity), _rb.velocity.y);
            animState = "IsMoving";

            // Flip the player sprite based on the movement direction
            transform.localScale = new Vector3(_moveDirection >= 0 ? 1 : -1, 1, 1);
        }

        if (!IsGrounded())
        {
            animState = "IsJumping";
        }

        _animator.SetTrigger(animState);
        _finalJumpForce = 0; // reset the jump force to the default value
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, new Vector2(0.5f, 0.5f), 0.0f, Vector2.down, 0.5f, groundMask);
        return raycastHit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + 
                            Vector3.down * 0.5f, 
                            new Vector3(0.5f, 0.5f, 0));
    }
}
