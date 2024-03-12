using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlicePuzzleManager : PuzzleManager
{
    public int requiredSlices = 20; // The number of objects that need to be sliced to clear the puzzle
    public float puzzleDuration = 10f; // Duration of the puzzle in seconds
    private int _slicesMade = 0;
    private float _timer = 0;
    private bool isCleared = false;
    
    public TextMeshProUGUI sliceCounterText; 
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI statusText;
    
    void Start()
    {
        base.Start();
        StartCoroutine(PuzzleTimer());
        UpdateUI(); // Initial UI update
    }

    void Update()
    {
        UpdateUI();
    }

    public void RegisterSlice()
    {
        _slicesMade++;
        if (_slicesMade >= requiredSlices)
        {
            isCleared = true;
            statusText.text = "Completed!";
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

        if (_slicesMade < requiredSlices)
        {
            // Handle puzzle failure (if needed)
            Debug.Log("Puzzle failed. Not enough slices made.");
            statusText.text = "Failed. Try again!";
        }

    }
    
    void UpdateUI()
    {
        if (sliceCounterText != null)
        {
            if (isCleared)
            {
                sliceCounterText.text = $"Cubes: 10/{requiredSlices}";
            }
            sliceCounterText.text = $"Cubes: {_slicesMade}/{requiredSlices}";
        }

        if (timerText != null)
        {
            timerText.text = $"Time: {_timer.ToString("0")}s";
        }
    }
    
}
