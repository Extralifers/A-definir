using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject mainMenu;
	bool isMenuActive;

	public GameObject deadMenu;

	// Use this for initialization
	void Start () {
		isMenuActive = false;
		if (mainMenu == null) {
			Debug.LogError ("There is no mainMenu attached!");
		}
		if (deadMenu == null) {
			Debug.LogError ("There is no deadMenu attached!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("Pause")){
			if(!deadMenu.activeSelf){
				if (isMenuActive) {
					mainMenu.SetActive (false);
					Time.timeScale = 1.0f;
					isMenuActive = false;
				} else {
					mainMenu.SetActive (true);
					Time.timeScale = 0.0001f;
					isMenuActive = true;
				}
			}
		}

	}

	public void Continue(){
		mainMenu.SetActive (false);
		Time.timeScale = 1.0f;
	}

	public void Restart(){
		SceneManager.LoadScene ("main");
		Time.timeScale = 1.0f;
	}

	public void Exit(){
		Application.Quit ();
	}
}
