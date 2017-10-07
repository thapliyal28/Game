using UnityEngine;
using System.Collections;

public class SetScore : MonoBehaviour {

	public GameObject newRecordText;
	public GUIText thisScoreObj ;
	public GUIText thisHighScoreObj ;
	string highScoreKey = "HighScore";
	string ScoreKey = "Score";

	void Start () {
		float score = PlayerPrefs.GetFloat (ScoreKey,0);
		float highScoreOld = PlayerPrefs.GetFloat(highScoreKey,0);
		//float score = 0;
		//float highScoreOld = 0;
		Debug.Log ("The Score is" + score.ToString());
		Debug.Log ("The highscore is" + highScoreOld.ToString());


		newRecordText.SetActive (false);

		if (score > highScoreOld) {
			newRecordText.SetActive(true);
		}

		thisScoreObj.text = "" + score.ToString();
		thisHighScoreObj.text = "" + highScoreOld.ToString();

	}
	

}
