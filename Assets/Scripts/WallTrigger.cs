using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WallTrigger : MonoBehaviour {

	public Estacion station;
	public GameObject stationScreen;
	public Text stationText;

	void OnTriggerEnter(){
		GameManager.instance.currentStation = station.ID;
		stationScreen.SetActive(true);
		stationText.text = MapManager.diccionarioNombre[station.ID];
		StartCoroutine(LateCall());
		GameObject.Find("Audio").GetComponent<SoundManager>().PlayAudio(station.ID);
	}

	public IEnumerator LateCall(){
		yield return new WaitForSeconds(5);
		stationScreen.SetActive(false);
	}
}