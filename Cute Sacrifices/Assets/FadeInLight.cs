using UnityEngine;
using System.Collections;

public class FadeInLight : MonoBehaviour {
	public float timer;
	public float waitingTime;
	public Light lighting;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		if(timer > waitingTime) {
			if(lighting.intensity < 0.8F) {
				lighting.intensity += 0.02F;
				timer = 0;
			}
		}
	}
}
