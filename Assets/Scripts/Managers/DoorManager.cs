using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DoorManager : MonoBehaviour
{
    [SerializeField] public List<PuzzleManager> Puzzles;
    private List<bool> _puzzlesBool = new List<bool>();
    public Action<DoorManager> OnDoorOpened;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        foreach (PuzzleManager puzzle in Puzzles)
        {
            puzzle.OnPuzzleComplete += PuzzleCleared;
            _puzzlesBool.Add(false);
        }
    }


    public void PuzzleCleared(PuzzleManager puzzle)
    {
        _puzzlesBool[Puzzles.IndexOf(puzzle)] = true;

        if (_puzzlesBool.All(element => element == true))
        {
            _animator.SetBool("PuzzleDone",true);
            OnDoorOpened?.Invoke(this);
        }
          
    }

    private void OnDestroy()
    {
        foreach (PuzzleManager puzzle in Puzzles)
        {
            puzzle.OnPuzzleComplete -= PuzzleCleared;
        }
    }
}
