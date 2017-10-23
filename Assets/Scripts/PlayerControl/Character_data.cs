using UnityEngine;
using System.Collections;

public class Character_data : MonoBehaviour
{

	[SerializeField]private GameObject player;
	public Vector3 currentCheckPoint;
	private bool isAlive = true;

	// Use this for initialization
	void Start ()
	{
		if (player != null) {
			currentCheckPoint = player.transform.localPosition;
		}
	}

	// Update is called once per frame
	void Update ()	{
		if (isdead ()) {
			ResetPlayer ();
			isAlive = true;
		}

	}

	// Check if the player is alive or not
	public bool isdead (){
		return isAlive;
	}

	// Kills the player
	public void kill(){
		isAlive = false;
	}

	void ResetPlayer ()	{
		player.transform.localPosition = currentCheckPoint;
	}
	/*
	void OnGUI ()	{
		DisplayNumberOfDeaths ();
	}

	void DisplayNumberOfDeaths ()	{
		string s = "Deaths : ";
		GUI.Box (new Rect (10, 50, s.Length + 70, 22), s + );
	}
	*/
}
