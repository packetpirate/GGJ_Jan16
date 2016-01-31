using UnityEngine;
using System.Collections;

public class letterShake : MonoBehaviour {

	public bool direction = true;
	public float timer = 0.1f;

	private float currentTimer;
	private float TimesDelta;

	// Use this for initialization
	void Start () {
		currentTimer = timer;
	
	}
	
	// Update is called once per frame
	void Update () {

		TimesDelta = Time.deltaTime;

		currentTimer -= TimesDelta;

		if (currentTimer >= 0f) {
			if (direction) {
				//goes up
				transform.Translate (Vector2.up * TimesDelta);
			
			} else {
				//goes down
				transform.Translate (Vector2.down * TimesDelta);
			}
		} else {
			direction = !direction;
			currentTimer = timer;
		}
	
	}
}
