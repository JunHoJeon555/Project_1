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
        rigid= GetComponent<Rigidbody>();
        enemyDestination = GetComponentInChildren<Destination>();
        enemyDestination.transform.SetParent(null);
        
        animator = GetComponent<Animator>();
    
    }

    private void Start()
    {
        moveTarget = enemyDestination.CurrentTarget;
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) //pendoing 중이 아니고, remainingDistansce가 stoopongDostance보다 작을 때 도착했다고 알림
        {
            moveTarget = enemyDestination.NextTarget();
            agent.SetDestination(moveTarget.position);
            animator.SetBool("Move", true);
        }
    }

    void Die()
    {
        onDie= true;
    }
}
