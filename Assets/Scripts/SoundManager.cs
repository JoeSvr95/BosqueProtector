using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SoundManager : MonoBehaviour {

	public int station;
	[DllImport("__Internal")]
    private static extern void StartAudio();
	[DllImport("__Internal")]
	private static extern void StopAudio();

	void Start(){
		PlayAudio();
	}

	public void PlayAudio(){
		StartAudio();
	}

	public void PauseAudio(){
		StopAudio();
	}
}
