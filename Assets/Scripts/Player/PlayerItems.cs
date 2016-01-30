using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerItems : MonoBehaviour {
	// Player items
	public float bagsize = 5;

	public GameObject bag_panel;


	private List<string> cuties;

	public void FixedUpdate(){
		for (int x = 1; x <= bagsize; x++) {
			RectTransform heart = (RectTransform)bag_panel.transform.FindChild ("bag " + x.ToString ());
			//Debug.Log ("bag " + cuties.Count + " ");
			if (x <= cuties.Count) { 
				heart.GetComponent<Image> ().color = Color.black;
			} else {
				heart.GetComponent<Image> ().color = Color.white;
			}

		}

	}

	public void Start(){
		cuties = new List<string>();
	}


	public void AddCutie(string name) {
		int n;

		// Check for numbers at the end of the object name.
		int i = name.LastIndexOf('_');
		if(i != -1) {
			if(int.TryParse(name.Substring(i + 1), out n)) {
				name = name.Remove(i);
			}
		}

		// Check for (Clone) at the end of the object name.
		i = name.IndexOf("(Clone)");
		if(i != -1) {
			name = name.Remove(i);
		}

		cuties.Add(name);
	}

	public List<string> GetCuties() {
		return new List<string>(cuties);
	}



	public void EmptyCuties() {
		cuties.Clear();
	}
}
