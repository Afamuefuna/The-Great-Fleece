using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;

    private Animator playerAnimator;

    private Vector3 target;

    public GameObject coin;
    public bool tossedCoin;

    public AudioClip coinSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitinfo;

            if(Physics.Raycast(rayOrigin, out hitinfo))
            {
                Debug.Log("Hit: " + hitinfo.point);

               // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
               // cube.transform.position = hitinfo.point;

                agent.destination = hitinfo.point;
                target = hitinfo.point;

                playerAnimator.SetBool("walk", true);
            }
            
        }

        float distance = Vector3.Distance(transform.position, target);

        if(distance < 1.0)
        {
            playerAnimator.SetBool("walk", false);
        }

        if (gameManager.Instance.givenInstruction == true)
        {
            if (Input.GetMouseButtonDown(1) && tossedCoin == false)
            {
                Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitinfo;

                if (Physics.Raycast(rayOrigin, out hitinfo))
                {
                    playerAnimator.SetTrigger("Throw");
                    tossedCoin = true;
                    Instantiate(coin, hitinfo.point, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(coinSoundEffect, transform.position);
                    sendAItoCoinSpot(hitinfo.point);
                }

            }
        }
        
        
     
    }

    void sendAItoCoinSpot(Vector3 coinPosition)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");

        foreach(var guard in guards)
        {
            NavMeshAgent currentNav = guard.GetComponent<NavMeshAgent>();
            guard currentGuard = guard.GetComponent<guard>();
            Animator currentGuardAnim = guard.GetComponent<Animator>();


            currentGuard.coinTossed = true;
            currentNav.SetDestination(coinPosition);
            currentGuardAnim.SetBool("walk", true);
            currentGuard.coinPos = coinPosition;
        }
    }
}
