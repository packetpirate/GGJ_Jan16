using UnityEngine;
using System.Collections;

public class generic_cutie : MonoBehaviour {
	public  float SPEED = 2;
	private bool PlayerInRange;
	private Rigidbody2D cutieRb2D;
	private GameObject player;

	private float timer;
	public float DirectionTimer;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		PlayerInRange = false;
		cutieRb2D = GetComponent<Rigidbody2D>();

		timer = 0.0F;
		direction = new Vector3(0.0F, 0.0F, 0.0F);
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
	void FixedUpdate () {
		timer += Time.deltaTime;

		if(timer > DirectionTimer) {
			direction.x = Mathf.Cos(Random.value * (Mathf.PI * 2)) * SPEED;
			direction.y = Mathf.Sin((Random.value * (Mathf.PI * 2))) * SPEED;
			timer = 0.0F;
		}

		if(PlayerInRange) {
			Vector3 pPos = player.transform.position;
			Vector3 cPos = transform.position;
			float pTheta = Mathf.Atan2((pPos.y - cPos.y), (pPos.x - cPos.x));
			float dx = -(Mathf.Cos(pTheta) * SPEED);
			float dy = -(Mathf.Sin(pTheta) * SPEED);
			cutieRb2D.AddForce(new Vector2(dx, dy));
		} else {
			cutieRb2D.AddForce(direction);
		}
	}
}
