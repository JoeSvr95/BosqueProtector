using UnityEngine;
using UnityEngine.UI;


public class BtnFunctions : MonoBehaviour {

	public int station;

	public void DisplayText (){
		GetComponentInChildren<Text> ().text = "Estacion " + station;
	}

	public void HideText (){
		GetComponentInChildren<Text> ().text = "";
	}

	public void GoToVisualizer() {
		Debug.Log("Visualizer estacion " + station);
	}
}
