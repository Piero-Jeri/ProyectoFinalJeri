using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float speed;
    //[SerializeField] private float waitTime;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else
        {
            //StartCoroutine(Wait());
            currentWaypoint++;

            if (currentWaypoint == waypoints.Length)
            {
                currentWaypoint = 0;
            }

            Flip();
        }

    }

    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }

        Flip();
    }*/

    private void Flip()
    {
        if (transform.position.x > waypoints[currentWaypoint].position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
