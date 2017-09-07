using UnityEngine;
using System.Collections;

public class PatrolPlatforme : MonoBehaviour
{


	//private string s = "";
	private int currentState = -1;
	[SerializeField]private Transform movingPlatform;
	[SerializeField]private Transform[] positions;

	private Vector3 newPosition;

	[SerializeField]private float speed;
	[SerializeField]private float loopTime;

	void Start ()
	{
		ChangeTarget ();
	}

	void FixedUpdate ()
	{
		movingPlatform.position = Vector3.Lerp (movingPlatform.position, newPosition, speed * Time.deltaTime);
	}

	void ChangeTarget ()
	{
		if (currentState == -1) {
			newPosition = positions [currentState + 2].position;
			currentState = currentState + 2;
		}
		newPosition = positions [currentState].position;
		currentState++;
		if (currentState == positions.Length) {
			currentState = 0;
		}
		Invoke ("ChangeTarget", loopTime);
	}

	public void OnDrawGizmos ()
	{
		for (int i = 0; i < positions.Length; i++) {
			if (i + 1 == positions.Length) {
				Debug.DrawLine (positions [i].position, positions [0].position, Color.blue);
			} else {
				Debug.DrawLine (positions [i].position, positions [i + 1].position, Color.blue);
			}
            
		}
        
	}
}
