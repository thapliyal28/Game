using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; // The parent of the spawn points
	public GameObject landingArea;
	public GameObject image1;
	public GameObject helicopter;

	private bool reSpawn = false;
	private Transform[] spawnPoints;
	private bool lastRespawnToggle = false;
	public Text Wintext;
	private float startTime;
	private float startTime2=0;
	public float elapsedTime;
	public float elapsedTime2;
	private const float minDistance = 5f;
	private const float minDistance2 = 10f;
	string highScoreKey = "HighScore";
	string ScoreKey = "Score";
	public float highScore = 0;
	public float Score = 0;
	public int s=0;
	public int s1=0;
	public int s2=0;
	public int s3=0;
	public int s4 =0; 

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform> ();
		Wintext.text = "";
		//ended.SetActive(true);
		startTime = Time.time;
		highScore = PlayerPrefs.GetFloat (highScoreKey, 0);
		Score = PlayerPrefs.GetFloat (ScoreKey, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f")) {
			Respawn ();
			reSpawn = false;
		} else {
			lastRespawnToggle = reSpawn;
		}

		if (Input.GetKeyDown ("g") && s == 0) {
			Invoke ("DropFlare", 3f);
			Debug.Log ("Flare dropped");
			s = 1;

		}
		if (Input.GetKeyDown ("p") && s2 == 0) {
			Application.LoadLevel("Mainmenu");
		} 
	
		elapsedTime = Time.time - startTime;

		PlayerPrefs.SetFloat(ScoreKey, elapsedTime);
		elapsedTime2 = Time.time - startTime2;
		if (elapsedTime2 >= 300f && s3 ==1) {
			helicopter.transform.position = landingArea.transform.position;
			s3 = 0;
		}

		Wintext.text = elapsedTime.ToString ();
		if ((helicopter.transform.position - transform.position).sqrMagnitude <= minDistance2 * minDistance2) {
			Debug.Log ("Made it!");

			AudioSource[] audios = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
			foreach (AudioSource aud in audios)
				aud.volume = 0;
			Wintext.text = " Game Over: You WON";
			s4 = 1;
			Time.timeScale = 0;


		}



		if ((Time.timeScale == 0 || transform.position.y <= 45) && s4 == 0) {
			Time.timeScale = 0;
			AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
			foreach(AudioSource aud in audios)
				aud.volume = 0;
	
			//ended.SetActive(true);
			if(transform.position.y >= 45)
			image1.SetActive(true);

			Wintext.text = " Game Over:" + elapsedTime.ToString ();
			if(elapsedTime>highScore){
				PlayerPrefs.SetFloat(highScoreKey, elapsedTime);
				PlayerPrefs.Save();
			}
			if (Input.GetKeyDown ("q"))
			{
				Application.LoadLevel("GameOverMenu");
			}


		}


	}
	

	private void Respawn() {
		int i = Random.Range (1, spawnPoints.Length);
		transform.position = spawnPoints [i].transform.position;
	}

	//void OnFindClearArea () {
	//	Invoke ("DropFlare", 3f);
	//}

	void DropFlare () {

		landingArea.transform.position = transform.position;
		landingArea.transform.rotation = transform.rotation;
		landingArea.SetActive (true);
		startTime2 = Time.time;
		s3 = 1;
	}


}
