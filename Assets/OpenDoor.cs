using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : PuzzleManager
{
    private PushButton _pushButton;
    private void Start()
    {
        _pushButton = GetComponent<PushButton>();
        _pushButton.OnButtonPressed += OpenDoorButton;
    }

    private void OpenDoorButton(BTType type)
    {
        Debug.Log("Open door");
        OnPuzzleComplete?.Invoke(this);
    }

    private void OnDestroy()
    {
        _pushButton.OnButtonPressed -= OpenDoorButton;

    }
}
