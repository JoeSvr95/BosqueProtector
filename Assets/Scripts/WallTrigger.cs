using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WallTrigger : MonoBehaviour {

	public Estacion station;
	public GameObject stationScreen;
	public Text stationText;

	void OnTriggerEnter(){
		GameManager.instance.currentStation = station.ID;
		GameObject.Find("Audio").GetComponent<SoundManager>().PlayAudio(station.ID);
		stationScreen.SetActive(true);
		stationText.text = "Estás en la estación: " + station.ID;
		StartCoroutine(LateCall());
	}

	public IEnumerator LateCall(){
		yield return new WaitForSeconds(5);
		stationScreen.SetActive(false);
	}
}
