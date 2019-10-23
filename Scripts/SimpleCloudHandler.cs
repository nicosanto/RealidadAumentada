using System;
using UnityEngine;
using Vuforia;

public class SimpleCloudHandler : MonoBehaviour, ICloudRecoEventHandler
{
	private CloudRecoBehaviour mCloudRecoBehaviour;
	private ObjectTracker mImageTracker;
	public ImageTargetBehaviour ImageTargetTemplate;
	UI_Manager scriptUIManager; //Script para acceder a los textos

	[System.Serializable]
	public class AugmentationObject {
		public string targetName;
		public GameObject augmentation;
	}

	public AugmentationObject[] AugmentationObjects;
	private bool mIsScanning = false;


	void Start () {
		CloudRecoBehaviour cloudRecoBehaviour = GetComponent<CloudRecoBehaviour>();
		if (cloudRecoBehaviour) {
			cloudRecoBehaviour.RegisterEventHandler(this);
		}

		mCloudRecoBehaviour = cloudRecoBehaviour;
		scriptUIManager = FindObjectOfType<UI_Manager> ();
	}

	public void OnInitialized() {
		mImageTracker = (ObjectTracker)TrackerManager.Instance.GetTracker<ObjectTracker>();
	}

	public void OnInitError(TargetFinder.InitState initError){}

	public void OnUpdateError(TargetFinder.UpdateState updateError){}

	public void OnStateChanged(bool scanning) {
		mIsScanning = scanning;
		if (scanning) {
			ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker> ();
			tracker.TargetFinder.ClearTrackables (false);
		}
	}

	//Se ejecuta cuando detecta el target y descarga la informacion de la nube
	public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult) {

		//Mensaje con el nombre del target y el contenido de la Metadata
		Debug.Log ("Nombre del Target: " + targetSearchResult.TargetName + "\nMetadata: " + targetSearchResult.MetaData);

		//Pasa el nombre del target y el contenido de la Metadata a los textos de la interfaz
		scriptUIManager.txtTargetName.text = targetSearchResult.TargetName;
		scriptUIManager.txtMetadata.text = targetSearchResult.MetaData;

		GameObject newImageTarget = Instantiate(ImageTargetTemplate.gameObject) as GameObject;
		GameObject augmentation = null;

		string targetName = targetSearchResult.TargetName; //Almacena el nombre del target

		if( augmentation != null )
			augmentation.transform.parent = newImageTarget.transform;

		ImageTargetBehaviour newImageTargetBehaviour = mImageTracker.TargetFinder.EnableTracking(targetSearchResult, newImageTarget);

		//Recorre el array de objetos, y desactiva todos excepto el del target que se encontro
		for (int i = 0; i < newImageTargetBehaviour.gameObject.transform.childCount; i++) {
			if (newImageTargetBehaviour.gameObject.transform.GetChild (i).gameObject.name != targetName) {
				newImageTargetBehaviour.gameObject.transform.GetChild (i).gameObject.SetActive (false);
			}
		}

		if (!mIsScanning) {
			mCloudRecoBehaviour.CloudRecoEnabled = true;
		}
	}

	


}