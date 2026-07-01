using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float tiempoAparición;

    private float tiempoSiguienteEnemigo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        if (tiempoSiguienteEnemigo >= tiempoAparición)
        {
            SpawnEnemy();
            tiempoSiguienteEnemigo = 0f;
        }
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab);
    }
}
