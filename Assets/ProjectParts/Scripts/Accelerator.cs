using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Accelerator : MonoBehaviour
{
    private XRBaseInteractable interactable;
    public bool isPressed;

    [SerializeField] private float pressedAngle = 20f;
    [SerializeField] private Vector3 rotationAxis = Vector3.right;
    [SerializeField] private float animationDuration = 0.10f;

    private Quaternion initialRotation;
    private Quaternion pressedRotation;
    private Coroutine rotateCoroutine;

    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        initialRotation = transform.localRotation;
        pressedRotation = initialRotation * Quaternion.AngleAxis(pressedAngle, rotationAxis);

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
            StartRotation(pressedRotation);

            isPressed = true;
        }
    }

    public void OnReleased(BaseInteractionEventArgs args)
    {
        // When released, return to initial rotation.
        StartRotation(initialRotation);
    }

    private void StartRotation(Quaternion target)
    {
        if (rotateCoroutine != null) StopCoroutine(rotateCoroutine);
        rotateCoroutine = StartCoroutine(RotateTo(target));
    }

    private IEnumerator RotateTo(Quaternion target)
    {
        Quaternion start = transform.localRotation;
        float elapsed = 0f;
        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);
            transform.localRotation = Quaternion.Slerp(start, target, t);
            yield return null;
        }

        transform.localRotation = target;
        rotateCoroutine = null;
    }
}