using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class ShowMenu : MonoBehaviour
{
    public InputActionProperty primaryButton;
    [SerializeField] GameObject locomotionMenu;
    [SerializeField] private Transform playerHead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (primaryButton.action.IsPressed()) {
            
            Vector3 offset = new Vector3(0, 0, 2);
            locomotionMenu.transform.position = playerHead.TransformPoint(offset);
            locomotionMenu.transform.rotation = playerHead.transform.rotation;

            if (locomotionMenu.activeInHierarchy)
                locomotionMenu.SetActive(false);
            else
                locomotionMenu.SetActive(true) ;
        }
    }
}
