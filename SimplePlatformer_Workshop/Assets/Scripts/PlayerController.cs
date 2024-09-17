using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    private Rigidbody2D _rb;
    private float _moveDirection;
    // life cycle functions
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = Input.GetAxisRaw("Horizontal"); // get move direction
    }

    // calls in a fixed frenquency per seconds(default 50 times per second)
    // it updates together with physics engine
    // executed after the Update() function
    void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_moveDirection * moveForce, 0), ForceMode2D.Force); // apply force
    }
}
