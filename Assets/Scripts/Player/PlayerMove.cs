using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 40f;
	public float cSpeed;

	public Canvas pauseMenu;

	private Rigidbody2D playerRb2D;
	private Animator playerAnim;
	//private PlayerItems m_Items;


	void Start(){
		//m_Items = GetComponent<PlayerItems> ();
		playerRb2D = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator>();
		cSpeed = speed;
	}

	// Update is called once per frame
	void Update () {
		/*if (Input.GetButtonDown("Pause")){
			is_paused = !is_paused;
			if (is_paused) {
				//pauseMenu.GetComponent<UIController>().pause();
			} else {
				//pauseMenu.GetComponent<UIController>().unpause();
			}
		}*/




		//Debug.Log (paused);


		float hor = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");

		//This moves him
		playerAnim.SetBool ("attacking", false);
		playerRb2D.AddForce(new Vector2(hor*cSpeed, vert*cSpeed));

		// sets his animation
		if (hor == 0 && vert == 0) {
			playerAnim.SetBool ("going_up", false);
			playerAnim.SetBool ("going_down", false);
			playerAnim.SetBool ("going_left", false);
			playerAnim.SetBool ("going_right", false);
			playerAnim.SetBool ("idle", true);
		}

		if (vert < 0) {
			playerAnim.SetBool ("going_up", false);
			playerAnim.SetBool ("going_down", true);
			playerAnim.SetBool ("going_left", false);
			playerAnim.SetBool ("going_right", false);
			playerAnim.SetBool ("idle", false);
		} else if (vert > 0) {
			playerAnim.SetBool ("going_up", true);
			playerAnim.SetBool ("going_down", false);
			playerAnim.SetBool ("going_left", false);
			playerAnim.SetBool ("going_right", false);
			playerAnim.SetBool ("idle", false);
		}

		if (hor < 0) {
			playerAnim.SetBool ("going_up", false);
			playerAnim.SetBool ("going_down", false);
			playerAnim.SetBool ("going_left", true);
			playerAnim.SetBool ("going_right", false);
			playerAnim.SetBool ("idle", false);
		} else if (hor > 0) {
			playerAnim.SetBool ("going_up", false);
			playerAnim.SetBool ("going_down", false);
			playerAnim.SetBool ("going_left", false);
			playerAnim.SetBool ("going_right", true);
			playerAnim.SetBool ("idle", false);
		}
		

	}
}
