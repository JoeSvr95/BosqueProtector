using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour {

	public static  bool IsPaused = false;
	public GameObject MenuPausaUI;

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (IsPaused){
				Continuar();
			} else {
				Pause();
			}
		}
	}

	public void Continuar(){
		MenuPausaUI.SetActive(false);
		Time.timeScale = 1f;
		IsPaused = false;
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
	}

	void Pause(){
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
		MenuPausaUI.SetActive(true);
		Time.timeScale = 0f;
		IsPaused = true;
	}

	public void MenuMapa(){
		GameManager.instance.LoadScene(1);
	}
}
