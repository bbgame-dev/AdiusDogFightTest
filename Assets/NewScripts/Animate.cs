using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animate : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Character character;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        float speed = agent.velocity.magnitude;

        anim.SetFloat("Speed", speed);
        anim.SetBool("Death" , character.isDead);
    }

}
