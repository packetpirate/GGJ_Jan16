using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PenController : MonoBehaviour {

	private float timer;
	public float spawnTime = 5;
	public int cutieCount = 5;
	private int maxCuties;

	public GameObject sheep;
	public GameObject piggy;
	public GameObject chick;

	// Use this for initialization
	void Start() {
		maxCuties = cutieCount;
		timer = 0.0F;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			Vector3 pos = transform.position;
			pos.y += 2.0F;
			List<string> cuties = other.gameObject.GetComponent<PlayerItems>().GetCuties();
			foreach(string cutie in cuties) {
				if(cutie.Contains("Pig")){
					Instantiate(piggy, pos, Quaternion.identity);
				}
				else if(cutie.Contains("Chick")){
					Instantiate(chick, pos, Quaternion.identity);
				}
				else {
					Instantiate(sheep, pos, Quaternion.identity);
				}
				cutieCount -= 1;
			}
			other.gameObject.GetComponent<PlayerItems>().EmptyCuties();
		}
	}

	// Update is called once per frame
	void FixedUpdate() {
		timer += Time.deltaTime;

		if (cutieCount <= 0) {
			//Application.LoadLevel (3);	
			UnityEngine.SceneManagement.SceneManager.LoadScene ("End Cutscene");
		}

		int numCuties = new List<GameObject>(GameObject.FindGameObjectsWithTag("cutie")).Count 
			          + GameObject.Find("Player").GetComponent<PlayerItems>().GetCuties().Count;
		//Debug.Log(numCuties + " cuties in level!");
		if((numCuties < maxCuties) && (timer > spawnTime)) {
			float randAnimal = Random.value;

			if (randAnimal <= .3) {
				Instantiate (sheep, new Vector3 (0.0F, 0.0F, 0.0F), Quaternion.identity);
			}
			else if (randAnimal <= .6) {
				Instantiate (chick, new Vector3 (0.0F, 0.0F, 0.0F), Quaternion.identity);
			} else {
				Instantiate (piggy, new Vector3 (0.0F, 0.0F, 0.0F), Quaternion.identity);
			}
			timer = 0.0F;
		}
	}
}
