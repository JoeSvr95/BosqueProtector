using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowMessage : MonoBehaviour {


	public GameObject Panel;
	public Text arbol;
	private bool ShowPanel;
	// Use this for initialization
	void Start () {
		ShowPanel = false;
		Panel.SetActive(ShowPanel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter() {

		ShowPanel = !ShowPanel;
		Cursor.visible = true;
	    Panel.SetActive(ShowPanel);
	}

	public void OnTriggerExit() {

		ShowPanel = !ShowPanel;
		Cursor.visible = false;
	    Panel.SetActive(ShowPanel);
		
	}
}
