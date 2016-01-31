using UnityEngine;
using System.Collections;

public class final_cutscene : MonoBehaviour {
	public GameObject person;
	public GameObject person_knife;
	public GameObject sheep;
	public GameObject sheep_dead;
	public GameObject pent_1;
	public GameObject pent_2;
	public GameObject pent_3;
	public GameObject pent_4;

	public GameObject demons_sound;

	float sceneLength = 0f;
	private Vector3 bumbFuck = new Vector3 (9999, 9999);
	private Vector3 centerStage = new Vector3 (0, 2);

	private float startTime;
	private float speed = 1f;

	private float journeyLength;

	private bool switched = false;
	private bool switched_sheep = false;
	private bool switched_penta1 = false;
	private bool switched_penta2 = false;
	private bool switched_penta3 = false;
	private bool switched_penta4 = false;

	// Use this for initialization
	void Start () {
		person_knife.transform.position = bumbFuck;
		sheep_dead.transform.position = bumbFuck;
		pent_1.transform.position = bumbFuck;
		pent_2.transform.position = bumbFuck;
		pent_3.transform.position = bumbFuck;
		pent_4.transform.position = bumbFuck;
		journeyLength = Vector3.Distance(person.transform.position, new Vector3(1f,-2f));
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		sceneLength += Time.deltaTime;

		if (sceneLength < 2) {
			//player walks to sheep
			startTime = Time.time;
		} else if (sceneLength < 3) {
			//player flips out over sheep
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			person.transform.position = Vector3.Lerp (person.transform.position, new Vector3 (1f, -2f), fracJourney);
		} else if (sceneLength < 4) {
			if (!switched) {
				person_knife.transform.position = person.transform.position;
				person.transform.position = bumbFuck;
				switched = true;
			}
		}else if (sceneLength < 5) {
			if (!switched_sheep) {
				sheep_dead.transform.position = sheep.transform.position;
				sheep.transform.position = bumbFuck;
				switched_sheep = true;
			}
			startTime = Time.time;
		}else if (sceneLength < 6) {
			if (!switched_penta1) {
				pent_1.transform.position = centerStage;
				switched_penta1 = true;
				demons_sound.GetComponent<AudioSource> ().Play ();
			}
		}else if (sceneLength < 7) {
			if (!switched_penta2) {
				pent_2.transform.position = centerStage;
				pent_1.transform.position = bumbFuck;
				switched_penta2 = true;
			}
		}
		else if (sceneLength < 8) {
			if (!switched_penta3) {
				pent_3.transform.position = centerStage;
				pent_2.transform.position = bumbFuck;
				switched_penta3 = true;
			}
		}
		else if (sceneLength < 9) {
			if (!switched_penta4) {
				pent_4.transform.position = centerStage;
				pent_3.transform.position = bumbFuck;
				switched_penta4 = true;
			}
		}

		else if (sceneLength > 30) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Credits Scene");
		}
	
	}
}
