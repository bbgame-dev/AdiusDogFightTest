using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{

    [SerializeField] MouseInput mouseInput;
    Movement Movement;

    private void Awake()
    {
        Movement = GetComponent<Movement>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Movement.SetDestination(mouseInput.mouseInputPosition);

        }
    }
}
