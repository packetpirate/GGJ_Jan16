using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInLight : MonoBehaviour {
	public float Timer;
	public float WaitingTime;
	public Light Lighting;
	public Text PlayGameText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Timer += Time.deltaTime;
		if(Timer > WaitingTime) {
			if (Lighting.intensity < 0.8F) {
				Lighting.intensity += 0.02F;
				Timer = 0;
			} else {
				// Display the menu button text.
				PlayGameText.text = "Play Game";
			}
		}
	}
}
