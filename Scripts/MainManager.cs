using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainManager : MonoBehaviour {
    public GameObject[] videoPlayer;
  
    public GameObject playbutton;
    public GameObject pausebutton;
    public GameObject nextbutton;
    public GameObject previewbutton;
    public GameObject mutebutton;
    public GameObject volumebutton;

    public GameObject MainCanvas;

    int CurrentPlayer = 0;

    // Use this for initialization
    void Start () {
        volumebutton.SetActive(false);
        DisableAll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play() {       
        MainCanvas.SetActive(true);
        videoPlayer[CurrentPlayer].SetActive(true);
        videoPlayer[CurrentPlayer].GetComponent<VideoPlayer>().Play();       
        playbutton.SetActive(false);
        pausebutton.SetActive(true);
        Volume();
    }

    public void Pause()
    {
        videoPlayer[CurrentPlayer].GetComponent<VideoPlayer>().Pause();
        pausebutton.SetActive(false);
        playbutton.SetActive(true);
    }

    public void Next()
    {
        //  videoPlayer[CurrentPlayer].GetComponent<VideoPlayer>().Stop();    //Agregue yo   
        videoPlayer[CurrentPlayer].SetActive(false);
        CurrentPlayer++;
        if (CurrentPlayer > 2) CurrentPlayer = 0;
        Play();
    }

    public void Preview()
    {
        videoPlayer[CurrentPlayer].SetActive(false);
       // videoPlayer[CurrentPlayer].GetComponent<VideoPlayer>().Stop();    //Agregue       
        CurrentPlayer--;    
        if (CurrentPlayer < 0) CurrentPlayer = 2;
        Play();
    }

    public void Mute()
    {
        videoPlayer[CurrentPlayer].GetComponent<AudioSource>().mute=true;
        mutebutton.SetActive(false);
        volumebutton.SetActive(true);
    }

    public void Volume()
    {
        videoPlayer[CurrentPlayer].GetComponent<AudioSource>().mute = false;
        volumebutton.SetActive(false);
        mutebutton.SetActive(true);
        
    }


    public void DisableAll()
    {
        MainCanvas.SetActive(false);
        foreach (var item in videoPlayer)
        {
            item.SetActive(false);
        }       
    }
    
}
