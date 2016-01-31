using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WolfAI : MonoBehaviour {
	public float SPEED;
	private bool CutieInRange;
	private Rigidbody2D wolfRb2D;
	public GameObject target;

	private float timer;
	public float DirectionTimer;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		CutieInRange = false;
		wolfRb2D = GetComponent<Rigidbody2D>();
		target = null;

		timer = 0.0F;
		direction = new Vector3(0.0F, 0.0F, 0.0F);
	}

	void OnTriggerStay2D(Collider2D other) {
		if((other.gameObject.tag == "cutie") && (target == null)) {
			CutieInRange = true;
			target = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if((other.gameObject.tag == "cutie") && (other == target)) {
			CutieInRange = false;
			target = null;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "cutie") {
			Destroy(other.gameObject);
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

		// Chase current target cutie.
		if(CutieInRange && (target != null)) {
			Vector3 tPos = target.transform.position;
			Vector3 cPos = transform.position;
			float tTheta = Mathf.Atan2((tPos.y - cPos.y), (tPos.x - cPos.x));
			float dx = Mathf.Cos(tTheta) * SPEED;
			float dy = Mathf.Sin(tTheta) * SPEED;
			wolfRb2D.AddForce(new Vector2(dx, dy));
		} else {
			wolfRb2D.AddForce(direction);
		}
	}
}
