using UnityEngine;
using System.Collections;

public class MoveBubbles : MonoBehaviour {
	public Vector2 bubbleSpeed = new Vector2 (-2.5f, 0f);
	private float maxBubbleSpeedDeviation;

	void Awake() {
		maxBubbleSpeedDeviation = 0.5f;
	}

	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (bubbleSpeed.x, Random.Range (-maxBubbleSpeedDeviation, maxBubbleSpeedDeviation));
	}
}
