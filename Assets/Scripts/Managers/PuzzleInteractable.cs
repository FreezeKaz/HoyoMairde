using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractable : MonoBehaviour
{

    public Action<PuzzleInteractable> OnCleared;
    // Start is called before the first frame update

    // Update is called once per frame
    public void InteractableCompleted()
    {
        OnCleared?.Invoke(this);
    }
}
