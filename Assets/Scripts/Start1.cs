using UnityEngine;
using System.Collections;

public class Start1 : MonoBehaviour {
	public string scenename = "Game";
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("s"))
			Application.LoadLevel(scenename);
	
	}
}
