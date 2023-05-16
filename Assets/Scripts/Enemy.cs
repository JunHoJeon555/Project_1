using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    Transform goalPoint;
    Rigidbody rigid;
    Animator animator;
    Transform moveTarget;
    public Action arrive;
    
    bool onDie = false;
    Destination enemyDestination;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //rigid= GetComponent<Rigidbody>();
        enemyDestination = FindObjectOfType<Destination>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        moveTarget = enemyDestination.CurrentTarget;
        //agent.SetDestination(moveTarget.position);
    }


    //IEnumerator TargetMove()
    //{
    //    while (!onDie)
    //    {
    //        if (agent.stoppingDistance < 0.1f)
    //        {
    //            moveTarget = enemyDestination.NextTarget();
    //            agent.SetDestination(moveTarget.position);
    //        }
    //        yield return new WaitForSeconds(1f);
    //    }
        
    //}
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            moveTarget = enemyDestination.NextTarget();
            agent.SetDestination(moveTarget.position);
        }
    }

    void Die()
    {
        onDie= true;
    }
}
