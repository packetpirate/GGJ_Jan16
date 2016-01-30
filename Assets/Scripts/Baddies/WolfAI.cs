using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WolfAI : MonoBehaviour {
	public float SPEED;
	private bool CutieInRange;
	private Rigidbody2D wolfRb2D;
	public GameObject target;

	// Use this for initialization
	void Start () {
		CutieInRange = false;
		wolfRb2D = GetComponent<Rigidbody2D>();
		target = null;
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
	void Update () {
		// Chase current target cutie.
		if(CutieInRange && (target != null)) {
			Vector3 tPos = target.transform.position;
			Vector3 cPos = transform.position;
			float tTheta = Mathf.Atan2((tPos.y - cPos.y), (tPos.x - cPos.x));
			float dx = Mathf.Cos(tTheta) * SPEED;
			float dy = Mathf.Sin(tTheta) * SPEED;
			wolfRb2D.AddForce(new Vector2(dx, dy));
		}
	}
}
