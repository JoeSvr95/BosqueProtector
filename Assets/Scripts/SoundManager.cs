using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	public int station;
	public Text prueba;
	[DllImport("__Internal")]
    private static extern void StartAudio(int station_id);
	[DllImport("__Internal")]
	private static extern void StopAudio();

	void Start(){
		//Debug.Log(MapManager.diccionarioID[GameManager.instance.currentStation]);
		PlayAudio(MapManager.diccionarioID[GameManager.instance.currentStation]);
	}

	public void PlayAudio(int id){
		StartAudio(id);
	}

	public void PauseAudio(){
		StopAudio();
	}
}
