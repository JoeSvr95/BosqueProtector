using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SoundManager : MonoBehaviour {

	private string server_addr = "http://stream.radioreklama.bg/nrj_low.ogg";
	public int station;
	[DllImport("__Internal")]
    private static extern void StartAudio(string addr);
	[DllImport("__Internal")]
	private static extern void StopAudio();

	void Start(){
		StartAudio(server_addr);
	}
}
