using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour
{
    public float MaxTimer;
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
    }
}
