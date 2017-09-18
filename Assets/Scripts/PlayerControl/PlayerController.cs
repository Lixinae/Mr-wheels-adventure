using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    //saut
    [SerializeField]
    private float _jumpSpeed;

    private bool _hasJumped;

    private bool _isGrounded;

    //mouvement
    [SerializeField]
    private Rigidbody _rigidbody;

    public float speed;



    void Start()
    {
        _hasJumped = false;
        _isGrounded = false;

        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _hasJumped = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _hasJumped = true;
        }
    }

    void FixedUpdate()
    {
        //saut
        if(_hasJumped && !_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.VelocityChange);
            _hasJumped = false;
            _isGrounded = false;
        }

        //mouvement horizontal

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		// Limite de vitesse sur l'axe X
        if (_rigidbody.velocity.x > 10 || _rigidbody.velocity.x < -10)
        {
            moveHorizontal = 0;
        }

		// Limite de vitesse sur l'axe Z
        if(_rigidbody.velocity.z > 10 || _rigidbody.velocity.z < -10)
        {
            moveVertical = 0;
        }

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        _rigidbody.AddForce(movement * speed);
		//print("velocity :"+rb.velocity.x+" "+ rb.velocity.y+" "+ rb.velocity.z);  
    }

    void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }
}
