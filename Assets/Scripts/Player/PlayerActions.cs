using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	public GameObject bomb;
	private PlayerItems m_Items;

	void Start() {
		m_Items = GetComponent<PlayerItems> ();
	}

	void OnTriggerStay2D(Collider2D other) {

	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "cutie") {
			// Pick up the cutie.
			m_Items.AddCutie(other.gameObject.name);
			Destroy(other.gameObject);
		}
	}

	public void Update(){
		
	}
}
