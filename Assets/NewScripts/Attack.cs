using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Character character;

    [SerializeField] float attackRange = 2.0f;
    [SerializeField] float defaultTimeAttack = 2.0f;
    float attackTimer;

    [SerializeField] Vector3 defaultPosition;

    Animator anim;
    Movement movement;

    Character target;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        movement = GetComponent<Movement>();
        character = GetComponent<Character>();
    }


    internal void AttackAction(Character target)
    {
        Debug.Log("Do Attack " + target.name);
        this.target = target;
        ProcessAttack();

    }

    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        attackTimerTick();

        if (target != null)
        {
            ProcessAttack();
        }
 
    }

    private void attackTimerTick()
    {
        if(attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    private void ProcessAttack()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        int damageValue = character.TakeStats(Statistic.Damage).integer_value;

        if (distance < attackRange)
        {
            if(attackTimer > 0f)
            {
                return;
            }

            attackTimer = GetAttackTime();

            movement.Stop();
            anim.SetTrigger("Attack");

            target.TakeDamage(damageValue, gameObject);  //sender damage value .  attacker 

            target = null;
        }
        else
        {
            movement.SetDestination(target.transform.position);
        }
    }

    float GetAttackTime()
    {
        float attackTime = defaultTimeAttack;

        attackTime /= character.TakeStats(Statistic.AttackSpeed).float_value;

        return attackTime;
    }
}
