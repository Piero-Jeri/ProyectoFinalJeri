using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoCaminar;
    public AudioClip sonidoDisparar;

    public void playCaminar()
    {
        audioSource.PlayOneShot(sonidoCaminar);
    }
    public void playDisparar() 
    {
        audioSource.PlayOneShot(sonidoDisparar);
    }
}