using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendLeg : MonoBehaviour
{
    private LeverInteractionScript isDown;

    public Vector3 startPos;
    public float extendDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;

        
        isDown = GetComponent<LeverInteractionScript>();
        if (isDown == null)
        {
            isDown = FindObjectOfType<LeverInteractionScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isDown != null && isDown.isPressed)
        {
            Vector3 target = new Vector3(startPos.x, startPos.y - extendDistance, startPos.z);
            if (transform.position != target)
            {
                transform.position = target;
            }
        }
    }
}
