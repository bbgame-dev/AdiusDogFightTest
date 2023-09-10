using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    [SerializeField] UIPoolBar hpBar;

    GameObject currentHoverObject;

    [HideInInspector]
    public Interact hoverObject;
    public Character hoverCharacter;

    Interact interactCharacter;

    [SerializeField] float interactRange = 0.05f;

    Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }




    private void Update()
    {
        CheckInteractedObject();

        if (Input.GetMouseButtonDown(0))
        {
            if(hoverObject != null)
            {
                hoverObject.Interacted();
            }

        }

        if(interactCharacter != null)
        {
            ProcessInteract();
        }

    }

    private void CheckInteractedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(currentHoverObject != hit.transform.gameObject)
            {
                currentHoverObject = hit.transform.gameObject;
                UpdateInteract(hit);
            }  
        }
    }

    internal void Interacted()
    {
        interactCharacter = hoverObject;
    }

    void ProcessInteract()
    {
        float distance = Vector3.Distance(transform.position, interactCharacter.transform.position);

        if(distance < interactRange)
        {
            interactCharacter.Interacted();
            movement.Stop();

            interactCharacter = null;
        }
        else
        {
            movement.SetDestination(interactCharacter.transform.position);
        }


    }

    private void UpdateInteract(RaycastHit hit)
    {
        Interact interactObject = hit.transform.GetComponent<Interact>();

        if (interactObject != null)
        {
            hoverCharacter = interactObject.GetComponent<Character>();
            hoverObject = interactObject;
            textOnScreen.text = hoverObject.ObjectName;

        }
        else
        {
            hoverCharacter = null;
            hoverObject = null;
            textOnScreen.text = "";
        }

        UpdateHPBar();
        Debug.Log("Updated HP Bar");
    }

    private void UpdateHPBar()
    {
        if(hoverCharacter != null)
        {
            hpBar.ShowHP(hoverCharacter.lifePool);
            Debug.Log("Showed HP Bar" + gameObject.name);
        }
        else
        {
            hpBar.ChearHP();
            Debug.Log("Clear HP Bar"  +gameObject.name);
        }
    }
}
