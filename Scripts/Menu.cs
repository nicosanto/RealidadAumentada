using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

    public void escanear() {
        SceneManager.LoadScene("escanear");
    }

    public void ayuda()
    {
        SceneManager.LoadScene("ayuda");
    }

    public void creditos()
    {
        SceneManager.LoadScene("creditos");
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
