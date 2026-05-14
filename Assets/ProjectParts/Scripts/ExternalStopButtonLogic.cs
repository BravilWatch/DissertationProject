using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExternalStopButtonLogic : MonoBehaviour
{
    private XRBaseInteractable interactable;
    public bool ExternalisPressed;

    [SerializeField] private float ButtonIndent = 0.5f;
    [SerializeField] private float animationDuration = 0.10f;

    private Vector3 InitialPosition;
    private Vector3 pressedPosition;
    private Coroutine PositionCoroutine;

    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        InitialPosition = transform.localPosition;
        pressedPosition = InitialPosition + new Vector3(-ButtonIndent, 0f, 0f);

        // Detect selection (grab) and release
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnPressed);
            interactable.selectExited.AddListener(OnReleased);
        }
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
            StartMovement(pressedPosition);
            ExternalisPressed = true;
        }
    }

    public void OnReleased(BaseInteractionEventArgs args)
    {
        // When released, return to initial position.
        StartMovement(InitialPosition);
        ExternalisPressed = false;
    }

    private void StartMovement(Vector3 target)
    {
        if (PositionCoroutine != null) StopCoroutine(PositionCoroutine);
        PositionCoroutine = StartCoroutine(MoveTo(target));
    }

    private IEnumerator MoveTo(Vector3 target)
    {
        if (animationDuration <= 0f)
        {
            transform.localPosition = target;
            PositionCoroutine = null;
            yield break;
        }

        Vector3 start = transform.localPosition;
        float elapsed = 0f;
        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);
            transform.localPosition = Vector3.Lerp(start, target, t);
            yield return null;
        }

        transform.localPosition = target;
        PositionCoroutine = null;
    }
}

