using UnityEngine;
using System.Collections;

public class SetCheckPoint : MonoBehaviour
{

	private bool printMessage = false;
	private float width = 120;
	private float height = 30;
	private string message = "CheckPoint Set";

	// Use this for initialization
	public void OnTriggerEnter (Collider col)
	{
		// = (Dead_restart)GameObject.Find("FPSController").GetComponent("Dead_restart");
		Character_data cd = col.GetComponent<Character_data> ();
		if (cd != null) {
			cd.currentCheckPoint = this.transform.position;
			StartCoroutine (waiting ());
		}
	}

	public void OnGUI ()
	{
		if (printMessage) {
			GUI.TextArea (new Rect (Screen.width / 2f - width / 2f, Screen.height / 2f - height / 2f, width, height), message);
		}
	}

	public IEnumerator waiting ()
	{
		printMessage = true;
		yield return new WaitForSeconds (3);
		printMessage = false;
	}

}
