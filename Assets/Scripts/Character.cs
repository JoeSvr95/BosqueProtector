﻿using UnityEngine;

public class Character : MonoBehaviour {

	public float Speed = 3f;
	public bool IsMoving {get; private set;}

	public Pin PinActual {get; private set;}
	private Pin PinDestino;
	private MapManager mapa;

	public void Iniciar(MapManager mapManager, Pin pinInicio){
		mapa = mapManager;
		SetPinActual(pinInicio);
	}

	private void Update(){
		if (PinDestino == null) {
			return;
		}

		var posicionActual = transform.position;
		var posicionDestino = PinDestino.transform.position;

		if (Vector3.Distance(posicionActual, posicionDestino) > .02f){
			transform.position = Vector3.MoveTowards(
				posicionActual,
				posicionDestino,
				Time.deltaTime * Speed
			);
		} else {
			if (PinDestino.EsAutomatico){
				var pin = PinDestino.GetPinSiguiente(PinActual);
				MoverAPin(pin);
			} else {
				SetPinActual(PinDestino);
			}
		}
	}

	public void TrySetDireccion(Direccion direccion){
		var pin = PinActual.GetPinEnDireccion(direccion);
		if (pin == null){
			return;
		}
		MoverAPin(pin);
	}

	public void MoverAPin(Pin pin){
		PinDestino = pin;
		IsMoving = true;
	}

	public void SetPinActual(Pin pin){
		PinActual = pin;
		PinDestino = null;
		transform.position = pin.transform.position;
		IsMoving = false;
		mapa.UpdateGUI();
	}

}
