using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AutoGrab : MonoBehaviour
{
    XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(Grabbed);
        grabInteractable.selectExited.AddListener(Released);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(Grabbed);
        grabInteractable.selectExited.RemoveListener(Released);
    }

    private void Grabbed(SelectEnterEventArgs arg)
    {
        // Optionally, set the object to follow the interactor more closely or apply any other custom logic on grab
    }

    private void Released(SelectExitEventArgs arg)
    {
        // Custom logic when the object is released, if any
    }
}
