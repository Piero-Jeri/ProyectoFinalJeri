using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    //public Button btn;
    void Start()
    {
        
    }

    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("FactoryMap");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Menu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }   

    void Update()
    {
        
    }
}
