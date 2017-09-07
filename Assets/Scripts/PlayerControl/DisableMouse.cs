using UnityEngine;
using System.Collections;

public class DisableMouse : MonoBehaviour
{

	private bool m_cursorIsLocked = true;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		lockUpdate ();
	}

	private void lockUpdate ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			m_cursorIsLocked = false;
		} else if (Input.GetMouseButtonUp (0)) {
			m_cursorIsLocked = true;
		}

		if (m_cursorIsLocked) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		} else if (!m_cursorIsLocked) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
