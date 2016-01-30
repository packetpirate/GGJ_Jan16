using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmerAI : MonoBehaviour {
	public float SPEED = 3;
	private bool PlayerInRange;
	private Rigidbody2D farmerRb2D;
	private GameObject player;

	public GameObject sheep;

	// Use this for initialization
	void Start () {
		PlayerInRange = false;
		farmerRb2D = GetComponent<Rigidbody2D>();
		player = GameObject.Find("Player");
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			PlayerInRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			PlayerInRange = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			List<string> cuties = other.gameObject.GetComponent<PlayerItems>().GetCuties();
			foreach(string cutie in cuties) {
				// spawn a cutie in a random theta around the player distance 2.0F
				Vector3 pPos = other.gameObject.transform.position;
				float fx = Random.value * (Mathf.PI * 2);
				float fy = Random.value * (Mathf.PI * 2);
				Vector3 cPos = new Vector3(((Mathf.Cos(fx) * 2.0F) + pPos.x),
										   ((Mathf.Sin(fy) * 2.0F) + pPos.y),
										   0);
				if(cutie == "Cutie_Sheep") {
					Instantiate(sheep, cPos, Quaternion.identity);
				}
			}
			other.gameObject.GetComponent<PlayerItems>().EmptyCuties();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerInRange) {
			Vector3 pPos = player.transform.position;
			Vector3 cPos = transform.position;
			float pTheta = Mathf.Atan2((pPos.y - cPos.y), (pPos.x - cPos.x));
			float dx = Mathf.Cos(pTheta) * SPEED;
			float dy = Mathf.Sin(pTheta) * SPEED;
			farmerRb2D.AddForce(new Vector2(dx, dy));
		}
	}
}