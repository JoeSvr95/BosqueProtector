using UnityEngine;

public class WallTrigger : MonoBehaviour {

	public Estacion station;

	void OnTriggerEnter(){
		GameManager.instance.estacionActual = station.ID;
	}
}
