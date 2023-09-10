using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    Character character;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<Character>();  
    }

    public void SetDestination(Vector3 destinationPosition)
    {
        if (!character.isDead)
        {
            agent.isStopped = false;
            agent.SetDestination(destinationPosition);
        }

        
    }

    internal void Stop()
    {
        agent.isStopped = true;
    }
}
