using UnityEngine;
using System.Collections;

public class ApplyForceOnTarget : MonoBehaviour {

    float strength = 30.0f;
     
	// Quand on rentre dans le trigger, on applique une force sur l'acteur entrant dedans
    public void OnTriggerEnter(Collider target){
        target.GetComponent<Rigidbody>().AddForce(gameObject.transform.rotation * Vector3.forward * strength, ForceMode.VelocityChange);
    }
}
