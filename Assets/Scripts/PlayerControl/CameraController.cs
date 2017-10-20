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
        if(mp != mouseWorldPosition)
        {
            Vector3 mpDiff = mp - mouseWorldPosition;
            float angle = mpDiff.x;
            //prendre le cote adjacent et l'hypothenus comme valeur pour deplacer, 
            //prendre le vecteur offset comme direction pour la premiere et le vecteur perpendiculaire pour la deuxieme
            //transform.position += new Vector3(1,0,1);
        }
        transform.LookAt(player.transform.position);
        offset = transform.position - player.transform.position;
        mouseWorldPosition = mp;
    }

}
