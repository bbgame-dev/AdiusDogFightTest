using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    InteractInput interactInput;
    Attack attack;

    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
        attack = GetComponent<Attack>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(interactInput.hoverCharacter != null)
            {
                attack.AttackAction(interactInput.hoverCharacter);
            }
        }
    }
}
