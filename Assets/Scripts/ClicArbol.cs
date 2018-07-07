using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ClicArbol : MonoBehaviour {

	public Canvas canvas;
	public bool IsGalery = false;
    
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            canvas.enabled = true;
	    	IsGalery = true;
            Pause();
        }

	if (Input.GetKeyUp(KeyCode.Q))
        {
            canvas.enabled = false;
	    	IsGalery = false;
            Continuar();
        }
    }
    
    public void Pause(){
    	canvas.enabled = !canvas.enabled;
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0f;
	}

	void Continuar(){
		Time.timeScale = 1f;
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
		Cursor.visible = false;
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
