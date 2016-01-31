using UnityEngine;
using System.Collections;

public class music_controller : MonoBehaviour {

	private AudioSource noise_maker;

	float timer = 2f;
	float ctimer;

	private float journeyLength;
	// Use this for initialization
	void Start () {
		noise_maker = GetComponent<AudioSource>();
		ctimer = timer + (Random.value * timer);

	
	}
	
	// Update is called once per frame
	void Update () {
		ctimer -= Time.deltaTime;
		if (ctimer <= 0) {
			ctimer = timer + (Random.value * timer);
			noise_maker.Play();
		}
	
	}
}
