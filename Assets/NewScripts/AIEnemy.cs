using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AIEnemy : MonoBehaviour
{
    Attack attack;
    Character character;
    Movement movement;

    [SerializeField] Vector3 defaultPosition;
    private void Awake()
    {
        attack = GetComponent<Attack>();
        character = GetComponent<Character>();
        movement = GetComponent<Movement>();
    }

    private void Start()
    {
        defaultPosition = transform.position;

    }

    [SerializeField] Character target;
    float timer = 0.0f;
    public float SpeedAttackTime = 1.0f;

    public float AttackRange =  10.0f;


    private void Update()
    {
        float attackPosition = Vector3.Distance(transform.position, defaultPosition);

        if (attackPosition  <= AttackRange)
        {

            if (character.attacker)
            {
                target = character.attacker?.GetComponent<Character>();
            }

            if (target && !target.isDead && !character.isDead)
            {
                timer -= Time.deltaTime;
                if(timer < 0f)
                {
                    Debug.Log("Stay Attack" + target.isDead);
                    timer = SpeedAttackTime;
                    attack.AttackAction(target);
                }

            }

        } else
        {
            target = null;
            character.attacker = null;
            movement.SetDestination(defaultPosition);

        }
    }



}
