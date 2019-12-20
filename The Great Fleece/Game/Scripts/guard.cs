using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class guard : MonoBehaviour
{
    public List<Transform> wayPoints;

    public int currentTarget;

    public NavMeshAgent _agent;

    public bool reverse;
    public bool targetReached;
    public bool coinTossed;

    public Animator guardAnim;

    public Vector3 coinPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null && coinTossed == false)
        {
            _agent.SetDestination(wayPoints[currentTarget].position);
            
                float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < 1)
            {
                guardAnim.SetBool("walk", false);
            }
            else
            {
                guardAnim.SetBool("walk", true);
            }

                if (distance < 1.0f && targetReached == false)
                {
                    targetReached = true;
                
                    if (reverse == true)
                    {
                        StartCoroutine(waitBeforeMoving());
                        
                    }
                    else
                    {
                        StartCoroutine(waitBeforeMoving());
                        
                    }
            }
         
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);

            if(distance < 6.0f)
            {
                guardAnim.SetBool("walk", false);
            }
        }
       

    }

    IEnumerator waitBeforeMoving()
    {
        float timeToWait = Random.Range(2, 6);

        yield return new WaitForSeconds(timeToWait);
        if (reverse == true)
        {
            currentTarget--;

            if (currentTarget == 0)
            {
                reverse = false;
                currentTarget = 0;
            }
        }
        else if (reverse == false)
        {
            currentTarget++;
            if (currentTarget == wayPoints.Count)
            {
                reverse = true;
                currentTarget--;
            }
        }
        targetReached = false;
    }
}
