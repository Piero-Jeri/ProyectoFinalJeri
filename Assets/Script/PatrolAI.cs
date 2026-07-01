using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public EnemyData EnemyData;


    [SerializeField] private float aparitionTime = 0;

    private bool Vulnerable = true;

    [SerializeField] private float speed;
    //[SerializeField] private float waitTime;
    [SerializeField] private List<GameObject> waypoints;

    public Animator animator;

    private int currentWaypoint;

    public waypointType waypointType;

    void Start()
    {
        Set();
    }

    // Update is called once per frame
    void Update()
    {
        APTime();

        


        if (Vulnerable == false)
        {
            Patrol();
        }


    }
    public void Set()
    {
       
        switch (waypointType)
        {
            case waypointType.None:
                break;
            case waypointType.one:
                waypoints = new(GameManager.instance.WaypointsE1);
                break;
            case waypointType.two:
                waypoints = new(GameManager.instance.WaypointsE2);
                break;
            case waypointType.three:
                waypoints = new(GameManager.instance.WaypointsE3);
                break;
            case waypointType.four:
                waypoints = new(GameManager.instance.WaypointsE4);
                break;
            case waypointType.five:
                waypoints = new(GameManager.instance.WaypointsE5);
                break;
            default:
                break;
        }
        aparitionTime = Random.Range(EnemyData.minTime, EnemyData.maxTime);
    }

    //public List<GameObject> Waypoints;

    private void APTime()
    {
        aparitionTime -= Time.deltaTime;

        if (aparitionTime <= 0)
        {
            Vulnerable = false;
            animator.SetBool("OnAparition", false);
        }
    }

    private void Patrol()
    {
        if (transform.position != waypoints[currentWaypoint].transform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            //StartCoroutine(Wait());
            currentWaypoint++;

            if (currentWaypoint == waypoints.Count)
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
        if (transform.position.x > waypoints[currentWaypoint].transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
