using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private Transform targetCamera;

    [SerializeField,Range(0,1)]
    private float efectoParallax;

    [SerializeField]
    private float longitudSprite;

    private float posicionIncial;
    void Start()
    {
        posicionIncial = transform.position.x;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float distanciaParalax = targetCamera.position.x * efectoParallax;
        transform.position = new Vector3(posicionIncial + distanciaParalax, transform.position.y, transform.position.z);
        float distanciaTemporal = targetCamera.position.x * (1 - efectoParallax);
        if(distanciaTemporal > posicionIncial + longitudSprite)
        {
            posicionIncial += longitudSprite;
        }
        else if (distanciaTemporal < posicionIncial - longitudSprite) { }
        {
            posicionIncial -= longitudSprite;
        }
    }
}
