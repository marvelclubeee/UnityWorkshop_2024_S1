using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D _rb;
    private float _moveDirection;
    private Animator _animator;

    private float _finalJumpForce;
    // life cycle functions
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = Input.GetAxisRaw("Horizontal"); // get move direction

        if(Input.GetButtonDown("Jump") && IsGrounded()){ // check whether the space button is pressed
            _finalJumpForce = jumpForce; // set the jump force
        } 
    }
    private bool IsGrounded(){
        // physics casting by shooting an invisible ray
        // Raycast(origin of the ray, direction of the ray, distance of the ray)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayer);
        if(hit.collider != null){ // check what the ray hits
            Debug.Log("Player is on: " + hit.collider.name);
        }
        return hit.collider != null; // return true if the ray hits the ground
    }

    // Life cycle function for drawing gizmos in the scene
    private void OnDrawGizmos(){ // draws the physics detection ray in the scene
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -1.0f, 0));
    }

    // calls in a fixed frenquency per seconds(default 50 times per second)
    // it updates together with physics engine
    // executed after the Update() function
    void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_moveDirection * moveForce, 0), ForceMode2D.Force); // apply force
        _rb.AddForce(new Vector2(0, _finalJumpForce), ForceMode2D.Impulse); // apply jump force

        string animState;
        if(Mathf.Abs(_moveDirection) <= 1e-10)
        { // check if the player is not pressing the move button
            _rb.velocity = new Vector2(0, _rb.velocity.y); // stop the player
            animState = "IsIdle";
        }else{
            animState = "IsMoving";
        }

        if(!IsGrounded()){
            animState = "IsJumping";
        }
        
        // flip the player sprite based on movement direction
        if(_moveDirection >= 0){
            transform.localScale = new Vector3(1, 1, 1); // face right
        }else{
            transform.localScale = new Vector3(-1, 1, 1); // face left
        }

        // limit the speed of the player
        // Mathf.Clamp(value, min, max) -> return value if value is between min and max, otherwise return min or max
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -5f, 5f), _rb.velocity.y);
        _animator.SetTrigger(animState); // set the animation state
        _finalJumpForce = 0; // reset the jump force
    }

}
