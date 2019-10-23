using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cloudDownloadScript : MonoBehaviour {
    public string url;
	
	void Start () {
        StartCoroutine(DownloadModel());
    }

    IEnumerator DownloadModel()
    {
        WWW www = new WWW(url);
        yield return www;
        AssetBundle assetBundle = www.assetBundle;
        //GameObject g = Instantiate(assetBundle.LoadAsset("Low poly book")) as GameObject;       
    }
}
