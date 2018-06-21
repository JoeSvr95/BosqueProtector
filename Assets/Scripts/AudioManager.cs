using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	WWW url;
	int station;
	string server = "http://revolutionradio.ru/live.ogg";

	void Awake(){
		station = GameManager.instance.estacionActual;
		url = new WWW(server);
	}

	IEnumerator Start(){
		while (url.progress < 0.01) {
        	Debug.Log(url.progress);
        	yield return new WaitForSeconds(.1f);
        }
		if (!string.IsNullOrEmpty(url.error)){
			Debug.Log(url.error);
		} else {
			AudioClip clipa = url.GetAudioClip(false, true, AudioType.OGGVORBIS);
			if (clipa.loadState == AudioDataLoadState.Loaded){
				GetComponent<AudioSource>().clip = clipa;
				GetComponent<AudioSource>().Play();
			}
		}
	}

}
