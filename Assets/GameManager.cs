using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//Esta clase controlará donde aparecerá el jugador en el bosque
	public static GameManager instance = null;
	public MapManager mapManager;
	public GameObject player;
	public GameObject[] spawnArray;
	public int estacionActual;
	public int escena = 0;

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
		if (mapManager)
		{
			mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
		}
		
	
		for (int i = 0; i < spawnArray.Length; i++){
			if (spawnArray[i].GetComponent<Estacion>().ID == estacionActual){
				GameObject spawn = spawnArray[i];
				if (escena == 1){
					player.transform.position = spawn.transform.position;
				} else if (escena == 0){
					mapManager.PinInicio = spawn.GetComponent<Pin>();
				}
			}
		}

	}
	
	public void LoadScene(int estacion){
		estacionActual = estacion;

		if (escena == 0){
			escena = 1;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		} else if (escena == 1){
			escena = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		} 
	}
}
