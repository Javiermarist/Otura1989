using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public void BotonJugar()
    {
        SceneManager.LoadScene("Scene_A");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    public void BotonSalirCreditos()
    {
        SceneManager.LoadScene("Menu");
    }
}
