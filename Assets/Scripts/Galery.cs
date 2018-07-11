using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Galery : MonoBehaviour {


	public Sprite[] imagenes;
	public int imagenActual = 0;
	public GameObject imagen;


	// Use this for initialization
	void Start () {
		CargarImagen(0);
	}

	void Update () {
		if (Input.GetKeyUp(KeyCode.RightArrow))
        {
			CargarImagen(1);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
			CargarImagen(-1);
        }
	}
	
	public void CargarImagen (int num) {
		imagenActual += num;
		if (imagenActual >= imagenes.Length) {
			imagenActual = imagenes.Length - 1;
		}
		if (imagenActual < 0) {
			imagenActual = 0;
		}
		imagen.GetComponent<Image>().sprite= imagenes[imagenActual];
	}
}
