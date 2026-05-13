using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 targetPos = target.transform.position;
        targetPos.z = -10;

        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }
}