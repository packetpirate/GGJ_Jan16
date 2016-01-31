using UnityEngine;
using System.Collections;

public class pause_menu : MonoBehaviour {

	public void ExitGame(){
		Application.Quit ();
	}

	public void StartLevel(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Intro");
	}

	public void StartMainMenu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Main Menu");

	}

	public void StartCreditsScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Credits Scene");
	}
}
