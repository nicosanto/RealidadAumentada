using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour, ITrackableEventHandler {

	TrackableBehaviour mTrackableBehaviour;
	public Text txtTargetName, txtMetadata; //Textos de la interfaz
	public UnityEngine.UI.Image imgDeteccion; //Para mostrar cuando se detecta un target

	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler (this);

		imgDeteccion.color = new Color (255, 0, 0, 255); //Cambio a color Rojo
	}

	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus) {
		if (newStatus == TrackableBehaviour.Status.DETECTED ||	newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			//Al detectar el target, habilita los textos
			txtTargetName.enabled = true;
			txtMetadata.enabled = true;

			//Atentos! Porque puede descargar la base de datos, pero si no detecta bien el target no va a mostrar el contenido
			imgDeteccion.color = new Color (0,255,0,255); //Cambio a color Verde
		} else if (previousStatus == TrackableBehaviour.Status.TRACKED &&  newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {  //pose
			//Al perder el target, deshabilita los textos
			txtTargetName.enabled = false;
			txtMetadata.enabled = false;

			//Vuelve a color Rojo
			imgDeteccion.color = new Color (255, 0, 0, 255); //Cambio a color Rojo
		} else {
			//NADA
		}
	}

}
