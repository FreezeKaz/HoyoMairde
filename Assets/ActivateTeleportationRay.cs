using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;


    public XRDirectInteractor leftDirectGrab;
    public XRDirectInteractor rightDirectGrab;

    public GameObject leftGrab;
    public GameObject rightGrab;

    // Update is called once per frame
    void Update()
    {
        leftTeleportation.SetActive(leftDirectGrab.interactablesSelected.Count == 0 && leftGrab.activeInHierarchy == false  && leftActivate.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(rightDirectGrab.interactablesSelected.Count == 0 && rightGrab.activeInHierarchy == false  && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
