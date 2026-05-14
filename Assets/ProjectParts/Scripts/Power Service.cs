using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Power_Service: MonoBehaviour
{
    private XRBaseInteractable interactable;
    public bool isDown;

    // Start is called before the first frame update
    void Start()
    {
        isDown = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDown == false)
        {
            if (other.gameObject.CompareTag("Air or Power"))
            {
                isDown = true;
            }
        }
    }
}
