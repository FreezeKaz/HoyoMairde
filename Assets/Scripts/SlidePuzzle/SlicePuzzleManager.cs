using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicePuzzleManager : PuzzleManager
{
    public int requiredSlices = 10; // The number of objects that need to be sliced to clear the puzzle
    public float puzzleDuration = 30f; // Duration of the puzzle in seconds
    private int _slicesMade = 0;
    private float _timer = 0;
    
    void Start()
    {
        base.Start(); // Call the start method of the base class
        StartCoroutine(PuzzleTimer());
    }

    void Update()
    {
        
    }

    public void RegisterSlice()
    {
        _slicesMade++;
        if (_slicesMade >= requiredSlices)
        {
            OnPuzzleComplete?.Invoke(this);
            // Optionally, stop the puzzle timer or handle puzzle completion
        }
        Debug.Log(_slicesMade);
    }

    IEnumerator PuzzleTimer()
    {
        _timer = puzzleDuration;
        while (_timer > 0)
        {
            _timer -= Time.deltaTime;
            yield return null;
        }

        // Time's up. Check if the puzzle is completed or failed
        if (_slicesMade < requiredSlices)
        {
            // Handle puzzle failure (if needed)
            Debug.Log("Puzzle failed. Not enough slices made.");
        }
    }
}
