using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapManager : MonoBehaviour {
	public Character character;
	public Pin PinInicio;
	public Text Estacion;

	private void Start(){
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
			SceneManager.LoadScene("Forest Scene");
		}
	}

	public void UpdateGUI(){
		Estacion.text = string.Format("Estacion: {0}", character.PinActual.Estacion);
	}

}
