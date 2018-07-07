using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System;

[Serializable]
public class Sensor
{
    public string DataId;
    public int StationId;
    public int SensorId;
    public int Id;
    public int Timestamp;
    public string Type;
    public string Value;
    public string Units;
    public string Location;
}

public class MapManager : MonoBehaviour {
	public Character character;
	public Pin PinInicio;
	public Text Estacion;
	public Text Cargando;
	public GameObject Panel;
	public Text TextSensor;

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
		if (Input.GetKeyUp(KeyCode.Return) && character.PinActual.estacion.ID != 0){
			GameManager.instance.LoadScene(character.PinActual.estacion.ID);
			Panel.SetActive(true);
			Cargando.text = string.Format("Entrando a la estación: " + character.PinActual.estacion.ID);
		}
		else if (Input.GetKeyUp(KeyCode.UpArrow)){
			character.TrySetDireccion(Direccion.Arriba);
		} else if (Input.GetKeyUp(KeyCode.DownArrow)){
			character.TrySetDireccion(Direccion.Abajo);
		} else if (Input.GetKeyUp(KeyCode.LeftArrow)){
			character.TrySetDireccion(Direccion.Izquierda);
		} else if (Input.GetKeyUp(KeyCode.RightArrow)){
			character.TrySetDireccion(Direccion.Derecha);
		}
	}

	public void UpdateGUI(){
		Estacion.text = string.Format("Estación: {0}", character.PinActual.estacion.ID);

		/* 
		if (character.PinActual.estacion.ID == 1 || character.PinActual.estacion.ID == 2 || character.PinActual.estacion.ID == 3){
			string sUrlRequest = "http://200.126.14.250/api/Station/" + character.PinActual.estacion.ID + "/Data/lastData";
			//string sUrlRequest = "http://200.126.14.250/api/Data/lastData";

	        var json = new WebClient().DownloadString(sUrlRequest);
	        Sensor datos = JsonUtility.FromJson<Sensor>(json);

	        TextSensor.text = string.Format("Temperatura: {0} {1}", datos.Value, datos.Units);
		}
		*/
	}

}
