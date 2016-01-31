using UnityEngine;
using System.Collections;

public class pause_menu : MonoBehaviour {

	public void ExitGame(){
		Application.Quit ();
	}

	public void StartLevel(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Intro");
		//Application.LoadLevel (1);
	}

	public void StartMainMenu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Main Menu");
		//Application.LoadLevel (2);
	}

	public void StartCreditsScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Credits Scene");
		Application.LoadLevel (4);
	}
}
