using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Habilidad : MonoBehaviour
{
    public KeyCode habilidadTecla = KeyCode.Tab;
    public GameObject circuloUI, dibujoUI;
    public float rangoVisibilidad = 30f;
    public float distanciaMaxima = 10f;
    public List<GameObject> objetivos = new List<GameObject>();
    public Camera cam;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        circuloUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(habilidadTecla))
        {
            if (DetectarObjetivo())
            {
                circuloUI.SetActive(true);
            }
            else
            {
                circuloUI.SetActive(false);
            }
        }
        else
        {
            circuloUI.SetActive(false);
        }
    }

    bool DetectarObjetivo()
    {
        Vector3 direccionCamara = cam.transform.forward;

        foreach (var objetivo in objetivos)
        {
            if (objetivo != null && objetivo.activeInHierarchy)
            {
                float distancia = Vector3.Distance(cam.transform.position, objetivo.transform.position);
                if (distancia <= distanciaMaxima)
                {
                    Vector3 direccionObjetivo = objetivo.transform.position - cam.transform.position;
                    float angulo = Vector3.Angle(direccionCamara, direccionObjetivo);
                    if (angulo < rangoVisibilidad)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

}