using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudUrl : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		// change url for you asset bundle path
		string url = "https://lesaro.com.ar/vuforia/";
		WWW www = new WWW (url);
		while (!www.isDone)
			yield return null;
		AssetBundle myasset = www.assetBundle;
		GameObject Mya = myasset.LoadAsset ("model") as GameObject;
		Instantiate (Mya);
	}
}