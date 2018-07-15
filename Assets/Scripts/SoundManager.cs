using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SoundManager : MonoBehaviour {

	public int station;
	[DllImport("__Internal")]
    private static extern void StartAudio(int station_id);
	[DllImport("__Internal")]
	private static extern void StopAudio();

	void Start(){
		PlayAudio(GameManager.instance.currentStation);
	}

	public void PlayAudio(int id){
		StartAudio(id);
	}

	public void PauseAudio(){
		StopAudio();
	}
}
