using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    //saut
    [SerializeField]
    private Transform _transform;

    [SerializeField]
    private float _jumpSpeed;

    [SerializeField]
    private Rigidbody _rigidbody;

    private float _feetRadius;

    private RaycastHit _hit;

    private bool _canJump = true;

    //mouvement
    public float speed;



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _feetRadius = GetComponent<SphereCollider>().radius;
    }

    void FixedUpdate()
    {
        //saut
        //print("test "+_canJump +" " + Input.GetAxis("Jump") + " " + _transform.position +" \n");
        print(Physics.SphereCast(_transform.position + Vector3.up * _feetRadius * 1.1f, _feetRadius, Vector3.down, out _hit, 0.1f));
        //print(_transform.position + Vector3.up * _feetRadius * 1.1f +" "+ _transform.position);
        if (!_canJump && Input.GetAxis("Jump") == 0)
        {
            _canJump = true;
        }
        if (_canJump && Input.GetAxis("Jump") > 0 && Physics.SphereCast(_transform.position + Vector3.up * _feetRadius * 1.1f, _feetRadius, Vector3.down, out _hit, 0.1f))
        {
            print("test2\n");
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.VelocityChange);
            _canJump = false;
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
}
