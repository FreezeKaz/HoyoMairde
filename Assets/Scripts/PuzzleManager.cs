using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public List<PuzzleInteractable> Interactables;

    public Action<PuzzleManager> OnPuzzleComplete;
    private List<bool> _interactablesBool = new List<bool>();

    void Start()
    {
        Interactables = new List<PuzzleInteractable>();
        _interactablesBool = new List<bool>();

        foreach(PuzzleInteractable interactable in Interactables)
        {
            interactable.OnCleared += InteractableCleared;
            _interactablesBool.Add(false);
        }
    }


    public void InteractableCleared(PuzzleInteractable interactable)
    {
        _interactablesBool[Interactables.IndexOf(interactable)] = true;

        if (_interactablesBool.All(element => element == true))
            OnPuzzleComplete.Invoke(this);
    }

    
    // Update is called once per frame
    void OnDestroy()
    {
        foreach (PuzzleInteractable interactable in Interactables)
        {
            interactable.OnCleared -= InteractableCleared;
        }
    }
}
