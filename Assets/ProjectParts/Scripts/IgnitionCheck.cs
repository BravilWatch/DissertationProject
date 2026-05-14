using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class IgnitionCheck : MonoBehaviour
{
    private XRBaseInteractable interactable;
    public bool isInserted;

    // Start is called before the first frame update
    void Start()
    {
        isInserted = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInserted == false)
        {
            if (other.gameObject.CompareTag("EngineKey"))
            {
                isInserted = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isInserted == true)
        {
            if (other.gameObject.CompareTag("EngineKey"))
            {
                isInserted = false;
            }
        }
    }
}
