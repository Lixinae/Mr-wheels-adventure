using UnityEngine;
using System.Collections;

public class UnCheckIsKinematicOnTriggerEnter : MonoBehaviour
{

	[SerializeField]
	private Rigidbody targetRigidbody;

	public void OnDrawGizmos ()
	{
		if (targetRigidbody != null)
			Debug.DrawLine (this.transform.position, targetRigidbody.transform.position, Color.yellow);
		
	}

	public void OnTriggerEnter (Collider col)
	{
		if (targetRigidbody) {
			targetRigidbody.isKinematic = false;
			targetRigidbody.WakeUp ();
		}
	}
}