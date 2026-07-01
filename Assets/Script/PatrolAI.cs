using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public EnemyData EnemyData;


    [SerializeField] private float aparitionTime = 0;

    private bool Vulnerable = true;

    [SerializeField] private float speed;
    //[SerializeField] private float waitTime;
    [SerializeField] private Transform[] waypoints;

    public Animator animator;

    private int currentWaypoint;

    void Start()
    {
        Set();
    }

    // Update is called once per frame
    void Update()
    {
        APTime();
        //Patrol();


        if (Vulnerable == false)
        {

        }


    }
    public void Set()
    {
        aparitionTime = Random.Range(EnemyData.minTime, EnemyData.maxTime);
    }



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
        if (transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            animator.SetBool("IsWalking", true);
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
