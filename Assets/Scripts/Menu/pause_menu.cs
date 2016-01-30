using UnityEngine;
using System.Collections;

public class pause_menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void StartLevel(){
		Application.LoadLevel (1);
	}

	public void StartMainMenu(){
		Application.LoadLevel (2);
	}

	public void StartCreditsScene(){
		Application.LoadLevel (4);
	}
}
