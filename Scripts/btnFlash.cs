using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class btnFlash : MonoBehaviour {

	public bool linterna = false;

	void Start () {
		//Desactiva la linterna al comenzar
		CameraDevice.Instance.SetFlashTorchMode (false);
	}

	//Activa o desactiva la linterna dependiendo la variable "linterna"
	public void botonLinterna () {
		linterna = !linterna;
		CameraDevice.Instance.SetFlashTorchMode (linterna);
	}

}
