using UnityEngine;
using System.Collections;

public class ggj : MonoBehaviour {

	float sceneLength = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		sceneLength += Time.deltaTime;
		if (sceneLength > 5) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Main Menu");
		}
	}
}
