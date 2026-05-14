using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class debug : MonoBehaviour
{
    StepsTakenChecker Debug;

    private XRBaseInteractable interactable;
    public bool isPressed;


    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();

        // Detect selection (grab) and release
        interactable.selectEntered.AddListener(OnPressed);
        interactable.selectExited.AddListener(OnReleased);
    }

    void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnPressed);
            interactable.selectExited.RemoveListener(OnReleased);
        }
    }

    public void OnPressed(BaseInteractionEventArgs args)
    {
        // Press only when the interactor is a grab/controller interactor.
        var interactorObj = args.interactorObject;
        if (interactorObj is XRDirectInteractor || interactorObj is XRRayInteractor || interactorObj is XRBaseControllerInteractor)
        {
            isPressed = true;

            
        }
    }

    public void OnReleased(BaseInteractionEventArgs args)
    {

    }

}
