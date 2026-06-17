using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float tiempoMaximo;
    private float tiempoActual;
    private bool tiempoActivo = false;

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
