using UnityEngine;
using System.Collections;

public class PressPause : MonoBehaviour {
	public GameObject hippo;
	public GameObject pausemenu;

	void Start () {
		// We hide the pauseMenu at the start of the game
		pausemenu.SetActive(false);
	}
	

	void Update () {
	#if UNITY_ANDROID
			checkTouchAndroid ();
		#endif
		
		#if UNITY_EDITOR
			checkTouchComputer();
		#endif	
	}


	void checkTouchAndroid() {
		for (int i = 0; i<Input.touches.Length; i++) {
            Touch touch = Input.GetTouch(i);
            Vector3 pos = touch.position;
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit != null && hit.collider != null) {
				switch(hit.collider.name) {
				case "PauseBtn":
					StartCoroutine(stopHippoFromMoving());
					Time.timeScale = 0.0f;
					pausemenu.SetActive(true);
					break;
				case "ResumeGame":
					Time.timeScale = 1.0f;
					pausemenu.SetActive(false);
					break;
				case "RestartGame":
					Application.LoadLevel("Play");
					Time.timeScale = 1.0f;
					break;
				case "GoHome":
					Application.LoadLevel("MainMenu");
					Time.timeScale=1.0f;
					break;
				}
			}
		}
	}

	void checkTouchComputer() {
		if (Input.GetMouseButtonUp(0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit != null && hit.collider != null)
			switch(hit.collider.name) {
				case "PauseBtn":
				StartCoroutine(stopHippoFromMoving());
				Time.timeScale = 0.0f;
				pausemenu.SetActive(true);
				break;
				case "ResumeGame":
				Time.timeScale = 1.0f;
				pausemenu.SetActive(false);
				break;
				case "RestartGame":
				Application.LoadLevel("Play");
				Time.timeScale = 1.0f;
				break;
				case "GoHome":
				Application.LoadLevel("MainMenu");
				Time.timeScale=1.0f;
				break;
			}
		}
	}

	IEnumerator stopHippoFromMoving() {
		yield return new WaitForSeconds(0.01f);
		hippo.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
	}

}
