using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BLACKTagReplaced : MonoBehaviour
{
    private XRBaseInteractable interactable;
    private BLACKTagChecker isPlaced;
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
        if (isPlaced.isDown == true)
        {
            if (isDown == false)
            {
                if (other.gameObject.CompareTag("BLACKTagHome"))
                {
                    isDown = true;
                }
            }
        }
        else
        {
            return;
        }
    }
}