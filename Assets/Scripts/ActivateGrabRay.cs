using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRay;
    public GameObject rightGrabRay;


    public XRDirectInteractor leftDirectGrab;
    public XRDirectInteractor rightDirectGrab;

    public InputActionProperty rightActivate;
    public InputActionProperty leftActivate;

    public GameObject leftTeleportation;
    public GameObject rightTeleportation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0 && leftTeleportation.activeInHierarchy == false && leftActivate.action.ReadValue<float>() > 0.1f);
        rightGrabRay.SetActive( rightDirectGrab.interactablesSelected.Count == 0 && rightTeleportation.activeInHierarchy == false && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
