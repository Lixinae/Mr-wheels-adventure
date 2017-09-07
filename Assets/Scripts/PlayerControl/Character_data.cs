using UnityEngine;
using System.Collections;

public class Character_data : MonoBehaviour
{

	[SerializeField]private GameObject player;
	private int countDeath = 0;

	public Vector3 currentCheckPoint;


	// Use this for initialization
	void Start ()
	{
		if (player != null) {
			currentCheckPoint = player.transform.localPosition;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		
		// if the player goes below -7 == he dies -> resest the position & rotation to the beginning
		if (isdead ()) {
			ResetPlayer ();
			countDeath++;
		}

	}

	public bool isdead ()
	{
		Vector3 playerCurrentPos;
		// get the current position of the player
		playerCurrentPos = player.transform.localPosition;
		return playerCurrentPos.y <= -7;
	}


	void ResetPlayer ()
	{
		player.transform.localPosition = currentCheckPoint;
	}

	void OnGUI ()
	{
		DisplayNumberOfDeaths ();
	}

	void DisplayNumberOfDeaths ()
	{
		string s = "Deaths : ";
		GUI.Box (new Rect (10, 50, s.Length + 70, 22), s + countDeath);
	}
}
