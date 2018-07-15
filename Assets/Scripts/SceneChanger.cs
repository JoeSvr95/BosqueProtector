using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

	public Animator animator;
	public int scene;
	public int stationToLoad;
	public GameObject LoadingScreen;
	public Slider slider;
	public Text progressText;

	private void Start(){
		scene = 0;
	}

	public void FadeToLevel(int station){
		stationToLoad = station;
		GameManager.instance.SetCurrentStation(station);
		animator.SetTrigger("fade_out");
	}

	public void LoadingLevel(){
		StartCoroutine(OnFadeComplete());
	}

	public IEnumerator OnFadeComplete(){
		AsyncOperation operation;
		
		if (GameManager.instance.scene == 0){
			GameManager.instance.scene = 1;
			operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

			while (!operation.isDone){
				float progress = Mathf.Clamp01(operation.progress / .9f);
				slider.value = progress;
				progressText.text = progress * 100f + "%";

				yield return null;
			}
		} else {
			GameManager.instance.scene = 0;
			operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
		}

	}
}
