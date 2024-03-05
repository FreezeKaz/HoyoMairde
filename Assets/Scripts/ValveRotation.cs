using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR.Interaction.Toolkit;

public class ValveRotation : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public Rigidbody valveRigidbody;
    public float rotationSpeed = 100f;

    private XRBaseInteractor grabbingInteractor;
    private Vector3 lastInteractorPosition;

    public bool IsFullyActivated;

    void Start()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
      
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        grabbingInteractor = args.interactor;
        lastInteractorPosition = grabbingInteractor.transform.position;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        grabbingInteractor = null;
    }
    void Update()
    {
        if (grabbingInteractor != null)
        {
            Vector3 currentInteractorPosition = grabbingInteractor.transform.position;
            Vector3 movementDirection = currentInteractorPosition - lastInteractorPosition;
            float rotationAmount = movementDirection.x * rotationSpeed * Time.fixedDeltaTime;
            valveRigidbody.AddTorque(Vector3.up * rotationAmount, ForceMode.VelocityChange);
        }
    }
}