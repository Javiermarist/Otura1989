using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Habilidad1 : MonoBehaviour
{
    public KeyCode habilidadTecla = KeyCode.E;
    public GameObject circuloUI, dibujoUI;
    public float rangoVisibilidad = 30f;
    public float distanciaMaxima = 10f;
    public List<GameObject> objetivos = new List<GameObject>();
    public Camera cam;
    public Sprite imagenCruz, imagenPersona, imagenRitual;
    public Image habilidadImagen;

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
        // Verificar si la tecla de habilidad está presionada
        if (Input.GetKey(habilidadTecla))
        {
            if (DetectarObjetivo())
            {
                circuloUI.SetActive(true);
                dibujoUI.SetActive(true);
            }
            else
            {
                circuloUI.SetActive(false);
                dibujoUI.SetActive(false);
            }
        }
        else
        {
            circuloUI.SetActive(false);
            dibujoUI.SetActive(false);
        }
    }

    bool DetectarObjetivo()
    {
        Vector3 direccionCamara = cam.transform.forward;

        // Buscar objetivos en la lista que están activos
        foreach (var objetivo in objetivos)
        {
            if (objetivo != null && objetivo.activeInHierarchy) // Verificar que el objetivo esté activo
            {
                float distancia = Vector3.Distance(cam.transform.position, objetivo.transform.position);
                if (distancia <= distanciaMaxima)
                {
                    Vector3 direccionObjetivo = objetivo.transform.position - cam.transform.position;
                    float angulo = Vector3.Angle(direccionCamara, direccionObjetivo);
                    if (angulo < rangoVisibilidad)
                    {
                        MostrarDibujo(objetivo);
                        return true;
                    }
                }
            }
        }

        return false;
    }

    void MostrarDibujo(GameObject objetivo)
    {
        if (objetivo.tag == "NPC")
        {
            habilidadImagen.sprite = imagenPersona;
        }
        else if (objetivo.tag == "cross")
        {
            habilidadImagen.sprite = imagenCruz;
        }
        else if(objetivo.tag == "Ritual")
        {
            habilidadImagen.sprite = imagenRitual;
        }
    }
}