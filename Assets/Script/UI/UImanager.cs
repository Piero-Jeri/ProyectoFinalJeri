using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Button btn;
    void Start()
    {
        
    }

    public void test()
    {

    }

    public void LoadScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }

    void Update()
    {
        
    }
}
