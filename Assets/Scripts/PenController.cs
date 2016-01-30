using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PenController : MonoBehaviour {
	private int cuties;
	private float timer;
	public float spawnTime = 5;
	public int cutieCount = 5;
	private int maxCuties;

	public GameObject sheep;

	// Use this for initialization
	void Start() {
		cuties = 0;
		maxCuties = cutieCount;
		timer = 0.0F;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			Vector3 pos = transform.position;
			pos.y += 2.0F;
			List<string> cuties = other.gameObject.GetComponent<PlayerItems>().GetCuties();
			foreach(string cutie in cuties) {
				Instantiate(sheep, pos, Quaternion.identity);
				cutieCount -= 1;
			}
			other.gameObject.GetComponent<PlayerItems>().EmptyCuties();
		}
	}

	// Update is called once per frame
	void FixedUpdate() {
		timer += Time.deltaTime;

		if (cutieCount <= 0) {
			Application.LoadLevel (3);	
		}

		int numCuties = new List<GameObject>(GameObject.FindGameObjectsWithTag("cutie")).Count 
			          + GameObject.Find("Player").GetComponent<PlayerItems>().GetCuties().Count;
		//Debug.Log(numCuties + " cuties in level!");
		if((numCuties < maxCuties) && (timer > spawnTime)) {
			Instantiate(sheep, new Vector3(0.0F, 0.0F, 0.0F), Quaternion.identity);
			timer = 0.0F;
		}
	}
}
