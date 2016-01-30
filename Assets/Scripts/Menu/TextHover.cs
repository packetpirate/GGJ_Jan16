using UnityEngine;
using System.Collections;

public class TextHover : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = new Color(228, 149, 149, 255);
	}

	void OnMouseEnter() {
		GetComponent<Renderer>().material.color = new Color(228, 66, 66, 255);
	}

	void OnMouseExit() {
		GetComponent<Renderer>().material.color = new Color(228, 149, 149, 255);
	}
}
