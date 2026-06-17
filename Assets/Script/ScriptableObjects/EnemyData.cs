using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Production Time/EnemyAparition")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float speed;
    public float minTime;
    public float maxTime;
   
}
