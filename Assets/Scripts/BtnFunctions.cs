using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnFunctions : MonoBehaviour {

	public int station;

	public void DisplayText (){
		GetComponentInChildren<Text> ().text = "Estacion " + station;
	}

	public void HideText (){
		GetComponentInChildren<Text> ().text = "";
	}

	public void GoToVisualizer() {
		// Esta función llama al visualizer correspondiente.
		SceneManager.LoadScene("Forest Scene");
	}
}
