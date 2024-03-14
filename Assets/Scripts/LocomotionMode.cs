using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionMode : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TeleportationProvider teleportationProvider;
    [SerializeField] ActivateTeleportationRay activateTeleportationRay;

    [SerializeField] ActionBasedContinuousMoveProvider actionBasedContinuousMoveProvider;


    [SerializeField] ActionBasedContinuousTurnProvider actionBasedContinuousTurnProvider;
    [SerializeField] ActionBasedSnapTurnProvider actionBasedSnapTurnProvider;


    [SerializeField] private PushButton _pushButtonLocomotion;
    [SerializeField] private PushButton _pushButtonRotation;

    private bool _locomotionType;
    private bool _rotationType;
    void Start()
    {
        _locomotionType = true;
        _pushButtonLocomotion.OnButtonPressed += ChangeLocomotion;
        _pushButtonRotation.OnButtonPressed += ChangeTurning;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLocomotion(BTType type)
    {
        Debug.Log(_locomotionType);
        _locomotionType = !_locomotionType;
        if (_locomotionType) {
            actionBasedContinuousMoveProvider.enabled = false;
            teleportationProvider.enabled = true; 
            activateTeleportationRay.enabled = true;
        }
        else {
            actionBasedContinuousMoveProvider.enabled = true;
            teleportationProvider.enabled = false;
            activateTeleportationRay.enabled = false;
            Debug.Log("Joyskick");
        }
    }

    public void ChangeTurning(BTType type)
    {

        _rotationType = !_rotationType;
        if (_rotationType)
        {
            actionBasedContinuousTurnProvider.enabled = false;
            actionBasedSnapTurnProvider.enabled = true;
        }
        else
        {
            actionBasedContinuousTurnProvider.enabled = true;
            actionBasedSnapTurnProvider.enabled = false;
        }
    }

    private void OnDestroy()
    {

        _pushButtonLocomotion.OnButtonPressed -= ChangeLocomotion;
        _pushButtonRotation.OnButtonPressed -= ChangeTurning;

    }
}
