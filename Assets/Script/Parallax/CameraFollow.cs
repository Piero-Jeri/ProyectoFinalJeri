using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //[SerializeField] private Transform target;
    public GameObject target;
    [SerializeField] private float followSpeed;

    private float target_poseX;
    private float target_poseY;

    private float posX;
    private float posY;

    public float derechaMax;
    public float izquierdaMax;

    public float alturaMax;
    public float alturaMin;

    private void Start()
    {
        
    }


    private void Awake()
    {
        //Vector3 targetPos = target.transform.position;
        posX = target_poseX + derechaMax;
        posY = target_poseY + alturaMin;

        /*Vector3 targetPos = new Vector3(posX, posY);
        targetPos.z = -10;*/

        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -10), 1);
    }

    private void moveCam()
    {
        if (target)
        {
            target_poseX = target.transform.position.x;
            target_poseX = target.transform.position.y;

            if (target_poseX > derechaMax && target_poseX < izquierdaMax)
            {
                posX = target_poseX;
            }

            if (target_poseY > alturaMax && target_poseY < alturaMin)
            {
                posY = target_poseY;
            }
        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -10), followSpeed * Time.deltaTime);
    }

    private void Update()
    {
        moveCam();
    }
}