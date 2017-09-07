using UnityEngine;
using System.Collections;

public class OnTriggerEnterPrintMessage : MonoBehaviour
{

	public float seconds;
	public string message;
	public int width;
	public int height;
	private bool printingMessage = false;

	public void OnGUI ()
	{
		if (printingMessage) {
			GUI.TextArea (new Rect (Screen.width / 2f - width / 2f, Screen.height / 2f - height / 2f, width, height), message);
		}
	}

	public IEnumerator waiting ()
	{
		printingMessage = true;
		yield return new WaitForSeconds (seconds);
		printingMessage = false;
	}
}
