using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerZone : MonoBehaviour
{
    public DoorManager doorManager;
    
        private void OnTriggerEnter(Collider other)
        {
            doorManager.OpenDoor();
        }
}
