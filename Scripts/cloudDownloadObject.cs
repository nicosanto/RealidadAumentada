using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudDownloadObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("DownloadObject");
	}
	
	// Update is called once per frame
	IEnumerator DownloadObject () {
        //WWW www = WWW.LoadFromCacheOrDownload("file://" + Application.dataPath + "/AssetBundles/objects", 1);
        WWW www = WWW.LoadFromCacheOrDownload(" http://develar.com.ar/scenes/" + Application.dataPath + "/AssetBundles/objects", 1);
       
        yield return www;

        AssetBundle bundle = www.assetBundle;
        AssetBundleRequest request = bundle.LoadAssetAsync<GameObject>("Cube");
        
        yield return request;

        GameObject cube = request.asset as GameObject;
        Instantiate<GameObject>(cube);
	}
}
