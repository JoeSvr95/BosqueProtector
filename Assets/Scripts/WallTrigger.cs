using UnityEngine;

public class WallTrigger : MonoBehaviour {

	public Estacion station;

	void OnTriggerEnter(){
		GameManager.instance.estacionActual = station.ID;
		GameObject.Find("Audio").GetComponent<SoundManager>().PlayAudio(station.ID);
	}
}
