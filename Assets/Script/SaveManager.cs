using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void LoadGame()
    {
        try
        {
            string data = System.IO.File.ReadAllText("save.txt");
            Debug.Log(data);
        }
        catch (Exception e)
        {
            Debug.LogError("Error al cargar partida: " + e.Message);
        }
    }
}
