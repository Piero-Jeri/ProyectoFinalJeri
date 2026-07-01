using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerController : MonoBehaviour
{
    public float MaxTimer; //= GameManager.instance.tiempoMaximo;
    public float currentTime;
    public Slider slider;
    void Start()
    {
        currentTime = MaxTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
        slider.value = currentTime / MaxTimer;

        if (currentTime <= 0)
        {
            Debug.Log("Noche pasada");
            SceneManager.LoadScene("YouWIn");
        }
    }
}
