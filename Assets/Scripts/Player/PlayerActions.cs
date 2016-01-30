using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {
	private PlayerItems m_Items;

	void Start() {
		m_Items = GetComponent<PlayerItems> ();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if((other.gameObject.tag == "cutie") && (m_Items.GetCuties().Count < m_Items.bagsize)) {
			// Pick up the cutie.
			m_Items.AddCutie(other.gameObject.name);
			Destroy(other.gameObject);
			GameObject.Find("Player").GetComponent<PlayerMove>().cSpeed -= 5;
		}
	}
}
