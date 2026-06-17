using UnityEngine;

public enum ProyectileType
{
    None,
    Spin,
    Throw,
    Falling
}

public class WeaponBase : MonoBehaviour
{
    public int Duration;
    public ProyectileType Type;
    public float speed;
    public float Rotationspeed;

    public Vector2 dir;

    void Start()
    {
        Destroy(gameObject, Duration);
        dir = randomDirecction();
    }

    void Update()
    {
        switch (Type)
        {
            case ProyectileType.None:
                break;
            case ProyectileType.Spin:
                transform.position += /*(Vector3)randomDirecction()*/ transform.up * speed * Time.deltaTime;
                transform.eulerAngles += Vector3.forward * Rotationspeed * Time.deltaTime;
                break;
            case ProyectileType.Throw:
                transform.position += (Vector3)dir * speed * Time.deltaTime;
                transform.eulerAngles += Vector3.forward * Rotationspeed * Time.deltaTime;

                break;
            case ProyectileType.Falling:
                transform.position += (Vector3)dir * speed * Time.deltaTime;
                transform.eulerAngles += Vector3.forward * Rotationspeed * Time.deltaTime;
                break;
            default:
                break;
        }
    }

    public Vector2 randomDirecction()
    {
        Vector2 randomDir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        return randomDir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {

        }
    }
}
