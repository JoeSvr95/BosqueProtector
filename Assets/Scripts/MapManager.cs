using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour {
	public Character character;
	public Pin PinInicio;
	public Text Estacion;
	public Text Cargando;
	//private bool entro = false;
	//private string mensaje;
	public GameObject Panel;

	private void Start(){
		Panel.SetActive(false);
		character.Iniciar(this, PinInicio);
	}

	public void Update(){
		if (character.IsMoving){
			return;
		}
		CheckForInput();
	}

	private void CheckForInput(){
		if (Input.GetKeyUp(KeyCode.UpArrow)){
			character.TrySetDireccion(Direccion.Arriba);
		} else if (Input.GetKeyUp(KeyCode.DownArrow)){
			character.TrySetDireccion(Direccion.Abajo);
		} else if (Input.GetKeyUp(KeyCode.LeftArrow)){
			character.TrySetDireccion(Direccion.Izquierda);
		} else if (Input.GetKeyUp(KeyCode.RightArrow)){
			character.TrySetDireccion(Direccion.Derecha);
		} else if (Input.GetKeyUp(KeyCode.Return)){
			//mensaje = "Entrando a la estación " + character.PinActual.estacion.ID;
			//entro = true;
			Panel.SetActive(true);
			Cargando.text = string.Format("Entrando a la estación: " + character.PinActual.estacion.ID);
			GameManager.instance.LoadScene(character.PinActual.estacion.ID);
		}
	}

	//private void OnGUI()
	//{
	    //GUIStyle myStyle = new GUIStyle();
	    //myStyle.fontSize = 20;
	    //if (entro)
	    //{
	    //	GUI.Box(new Rect(Screen.width/2-75,Screen.height/2-25,150,50), mensaje);
	    //}
	    
	//}

	public void UpdateGUI(){
		Estacion.text = string.Format("Estación: {0}", character.PinActual.estacion.ID);
	}

}
