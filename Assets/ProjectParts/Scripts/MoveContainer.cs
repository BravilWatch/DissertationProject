using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveContainer : MonoBehaviour
{
    private Accelerator isDown;
    private ButtonLogic isBraking;

    public Vector3 startPos;
    public float extendDistance = 0.6f;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;


        isDown = GetComponent<Accelerator>();
        isBraking = GetComponent<ButtonLogic>();
        if (isDown == null)
        {
            isDown = FindObjectOfType<Accelerator>();
        }
        if (isBraking == null)
        {
            isBraking = FindObjectOfType<ButtonLogic>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isDown != null && isDown.isPressed)
        {
            if (isBraking != null && isBraking.isPressed)
            {
                Vector3 target = new Vector3(startPos.x, startPos.y, startPos.z - extendDistance);
                if (transform.position != target)
                {
                    transform.position = target;
                }
            }
            
        }
    }
}