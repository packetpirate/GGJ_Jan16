using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PenController : MonoBehaviour {
	private int cuties;

	public int cutieCount = 5;

	public GameObject sheep;

	// Use this for initialization
	void Start () {
	
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
	void Update () {
		if (cutieCount <= 0) {
			Application.LoadLevel (3);	
		}
	}
}
