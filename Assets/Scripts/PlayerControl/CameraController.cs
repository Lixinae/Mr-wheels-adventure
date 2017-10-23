using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    private Vector3 mouseWorldPosition;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        mouseWorldPosition = Input.mousePosition;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
        Turn();
	}

    private void Turn()
    {
        Vector3 mp = Input.mousePosition;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        if (mp != mouseWorldPosition)
        {
            Vector3 mpDiff = mp - mouseWorldPosition;
            float angle = mpDiff.x;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            Vector3 pos = rotation * offset + player.transform.position;
            transform.rotation = rotation;
            transform.position = pos;
            transform.LookAt(player.transform.position);
        }
        offset = transform.position - player.transform.position;
        mouseWorldPosition = Input.mousePosition;
    }

}
