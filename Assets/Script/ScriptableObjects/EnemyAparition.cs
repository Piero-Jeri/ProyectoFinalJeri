using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAparition", menuName = "Production Time/EnemyAparition")]
public class EnemyAparition : ScriptableObject
{
    public string enemyName;
    public float speed;
    public float AparitionTime;
    public float currentTime;

    void Start()
    {
        currentTime = AparitionTime;
    }

    void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
    }
}
