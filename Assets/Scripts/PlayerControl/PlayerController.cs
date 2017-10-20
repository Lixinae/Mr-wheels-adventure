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

    //boost
    private Vector3 _boost = Vector3.zero;
    private bool stuck = false;


    void Start()
    {
        _hasJumped = false;
        _isGrounded = false;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //jump
        _hasJumped = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _hasJumped = true;
        }

        //arret du perso + boost au maintien
        if (Input.GetKeyDown(KeyCode.X))
        {
            _rigidbody.velocity = Vector3.zero;
            stuck = true;
        }
        if (Input.GetKey(KeyCode.X))
        {
            _rigidbody.velocity = Vector3.zero;
            _boost.x += Input.GetAxis("Horizontal");
            _boost.z += Input.GetAxis("Vertical");
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            _rigidbody.AddForce(_boost * speed);
            _boost = Vector3.zero;
            stuck = false;
        }
    }

    void FixedUpdate()
    {
        //arret du perso
        if (stuck)
        {
            return;
        }

        //saut
        if (_hasJumped && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.VelocityChange);
            _hasJumped = false;
            _isGrounded = false;
        }

        //mouvement fleche directionnel
        move_directional();

        //mouvement camera en fonction souris
    }

    void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    //mouvement plat
    private void move_directional()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Limite de vitesse sur l'axe X
        if (_rigidbody.velocity.x > 10 || _rigidbody.velocity.x < -10)
        {
            moveHorizontal = 0;
        }

        // Limite de vitesse sur l'axe Z
        if (_rigidbody.velocity.z > 10 || _rigidbody.velocity.z < -10)
        {
            moveVertical = 0;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        _rigidbody.AddForce(movement * speed);
        //print("velocity :"+_rigidbody.velocity.x+" "+ _rigidbody.velocity.y+" "+ _rigidbody.velocity.z);  
    }

}
