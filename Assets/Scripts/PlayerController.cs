using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		// Limite de vitesse sur l'axe X
        if (rb.velocity.x > 10 || rb.velocity.x < -10)
        {
            moveHorizontal = 0;
        }

		// Limite de vitesse sur l'axe Z
        if(rb.velocity.z > 10 || rb.velocity.z < -10)
        {
            moveVertical = 0;
        }

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(movement * speed);
		print("velocity :"+rb.velocity.x+" "+ rb.velocity.y+" "+ rb.velocity.z);  

    }
}
