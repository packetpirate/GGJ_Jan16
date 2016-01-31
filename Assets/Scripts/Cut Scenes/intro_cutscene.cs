using UnityEngine;
using System.Collections;

public class intro_cutscene : MonoBehaviour {

	public GameObject person;
	public GameObject sheep;
	public GameObject dream1;
	public GameObject dream2;

	float sceneLength = 0f;
	private Vector3 bumbFuck = new Vector3 (9999, 9999);
	private Vector3 centerStage = new Vector3 (0, 2);
	private float startTime;
	private float speed = 1f;

	private float journeyLength;

	// Use this for initialization
	void Start () {
		dream1.transform.position = bumbFuck;
		dream2.transform.position = bumbFuck;
		journeyLength = Vector3.Distance(person.transform.position, new Vector3(.5f,-2f));

	
	}
	
	// Update is called once per frame
	void Update () {
		sceneLength += Time.deltaTime;

		if (sceneLength < 2) {
			//player walks to sheep
			startTime = Time.time;
		}
		else if (sceneLength < 3) {
			//player flips out over sheep
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			person.transform.position = Vector3.Lerp(person.transform.position, new Vector3(.5f,-2f), fracJourney);


		}
		else if (sceneLength < 5) {
			//dream 1 shows up
			dream1.transform.position = centerStage;
		}
		else if (sceneLength < 7) {
			//dream 2 shows up
			dream1.transform.position = bumbFuck;
			dream2.transform.position = centerStage;
		}


		if (sceneLength > 8) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Level_1");
			//Application.LoadLevel (1);	
		}
	
	}
}
