using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//Esta clase controlará donde aparecerá el jugador en el bosque
	public static GameManager instance = null;
	public GameObject player;
	public GameObject[] spawnArray;
	public int estacionActual;

	void Awake () {
		if (instance == null){
			DontDestroyOnLoad(gameObject);
			instance = this;
		} else if (instance != null){
			Destroy(gameObject);
		}

		if (player == null){
			player = GameObject.FindGameObjectWithTag("Player");
		}

		if (spawnArray.Length == 0){
			spawnArray = GameObject.FindGameObjectsWithTag("Spawn");
		}
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		player = GameObject.FindGameObjectWithTag("Player");
		spawnArray = GameObject.FindGameObjectsWithTag("Spawn");

		for (int i = 0; i < spawnArray.Length; i++){
			if (spawnArray[i].GetComponent<Estacion>().ID == estacionActual){
				player.transform.position = (Vector3)spawnArray[i].transform.position;
			}
		}
	}
	
	public void LoadScene(int estacion){
		estacionActual = estacion;

		if (SceneManager.GetActiveScene().buildIndex == 0){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		} else if (SceneManager.GetActiveScene().buildIndex == 1){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		} 
	}
}
