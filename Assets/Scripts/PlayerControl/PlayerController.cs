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

    //mouvement en fonction de la direction de la camera
    [SerializeField]
    private GameObject Camera;

    private Vector3 offset;

    //boost
    private Vector3 _boost = Vector3.zero;
    private bool stuck = false;


    void Start()
    {
        _hasJumped = false;
        _isGrounded = false;
        _rigidbody = GetComponent<Rigidbody>();
        offset = Camera.transform.position - transform.position;
        print(offset)
            ;
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


        offset = Camera.transform.position - transform.position;
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
    }

    void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    //mouvement plat
    private void move_directional()
    {
        //gauche droite
        float moveHorizontal = Input.GetAxis("Horizontal");
        //avant arrière
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

        float dist_cam_player = Mathf.Sqrt((offset.y * offset.y) + (Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z)));
        Vector3 movement = new Vector3(((-offset.x) * (moveVertical + moveHorizontal)) / dist_cam_player, 0, ((-offset.z) * moveVertical) / dist_cam_player);

        _rigidbody.AddForce(movement * speed);
    }

}
