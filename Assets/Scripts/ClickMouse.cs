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
	public GameObject Panel3;
	public static bool IsGalery = false;

	public string titulo;
	public string cuerpo;
	public Text txttitulo;
	public Text txtcuerpo;


	public Sprite[] imagenes;
	public int imagenActual = 0;
	public GameObject imagen;
	Sprite[] imagenes2;


	void Start () {
		Panel.SetActive(false);		
	}

    void OnMouseDown ()
    {
    	imagenActual = 0;
    	txttitulo.GetComponent<Text>().text = titulo;
    	txtcuerpo.GetComponent<Text>().text = cuerpo;
        imagenes2 = imagenes;
        CargarImagen(0);
        Panel.SetActive(true);
        Panel3.SetActive(false);
        IsGalery = true;
        Pause();
    }

	void Update()
    {
		if (Input.GetKeyUp(KeyCode.Q))
        {
			Continuar();
			imagenActual = 0;
			limpiarArreglo();
        }
        if (IsGalery) {
        	if (Input.GetKeyUp(KeyCode.RightArrow))
	        {
				CargarImagen(1);
	        }
	        if (Input.GetKeyUp(KeyCode.LeftArrow))
	        {
				CargarImagen(-1);
	        }
        }
        
    }
    
    public void Pause(){
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0f;
	}

	public void Continuar(){
		Time.timeScale = 1f;
		GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
		Cursor.visible = false;
		Panel.SetActive(false);
		Panel3.SetActive(true);
		IsGalery = false;
	}

	public bool GetIsGalery() {
		return IsGalery;
	}

	public void CargarImagen (int num) {
		imagenActual += num;
		if (imagenActual >= imagenes2.Length) {
			imagenActual = imagenes2.Length - 1;
		}
		if (imagenActual < 0) {
			imagenActual = 0;
		}
		imagen.GetComponent<Image>().sprite= imagenes2[imagenActual];
	}

	public void limpiarArreglo (){
		for ( int i = 0; i < imagenes2.Length; i++)
			{
			imagenes2[i] = null;
			}
	}
    
}
