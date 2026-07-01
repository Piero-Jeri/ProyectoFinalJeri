using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum waypointType 
{

    None,
    one,
    two,
    three,
    four,
    five

}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float tiempoMaximo;
    private float tiempoActual;
    private bool tiempoActivo = false;

    public GameObject Player;

    public List<GameObject> WaypointsE1;

    public List<GameObject> WaypointsE2;

    public List<GameObject> WaypointsE3;

    public List<GameObject> WaypointsE4;

    public List<GameObject> WaypointsE5;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (tiempoActivo)
        {
            CambiarContador();

        }
    }

    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            Debug.Log("Noche pasada");
            tiempoActivo = false;
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivo = estado;
    }

    public void ActivarTemporizador()
    {
        CambiarTemporizador(true);
    }
    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }

}
