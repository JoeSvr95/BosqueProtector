using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ClickMouse : MonoBehaviour {

	public GameObject Panel;
	public GameObject Panel2;
	public GameObject Panel3;
	public static bool IsGalery = false;

	void Start () {
		Panel.SetActive(false);		
	}

    void OnMouseDown ()
    {
        Panel.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        IsGalery = true;
        Pause();
    }

	void Update()
    {
		if (Input.GetKeyUp(KeyCode.Q))
        {
			Continuar();
			IsGalery = false;
        }
    }
    
    public void Pause(){
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0f;
	}

	void Continuar(){
		Time.timeScale = 1f;
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
		Cursor.visible = false;
		Panel.SetActive(false);
		Panel3.SetActive(true);
	}

	public bool GetIsGalery() {
		return IsGalery;
	}
    
    public void Quit()
    {
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }
}
