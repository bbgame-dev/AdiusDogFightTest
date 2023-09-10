using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] string posMessage;
    public string ObjectName;
    private void Start()
    {
        ObjectName = transform.name;
    }

    public void Interacted()
    {
        Debug.Log(posMessage);
    }
}
