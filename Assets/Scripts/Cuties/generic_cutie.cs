using UnityEngine;
using System.Collections;

public class generic_cutie : MonoBehaviour {
	public  float SPEED = 2;
	private bool PlayerInRange;
	private Rigidbody2D cutieRb2D;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		PlayerInRange = false;
		cutieRb2D = GetComponent<Rigidbody2D>();
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

	// Update is called once per frame
	void Update () {
		if(PlayerInRange) {
			Vector3 pPos = player.transform.position;
			Vector3 cPos = transform.position;
			float pTheta = Mathf.Atan2((pPos.y - cPos.y), (pPos.x - cPos.x));
			float dx = -(Mathf.Cos(pTheta) * SPEED);
			float dy = -(Mathf.Sin(pTheta) * SPEED);
			cutieRb2D.AddForce(new Vector2(dx, dy));
		}
	}
}
