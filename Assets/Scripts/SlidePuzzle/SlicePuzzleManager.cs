using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlicePuzzleManager : PuzzleManager
{
    public int requiredSlices = 20; // The number of objects that need to be sliced to clear the puzzle
    private int _slicesMade = 0;
    private float _timer = 0;
    private bool isCleared = false;
    
    public TextMeshProUGUI sliceCounterText; 
    public TextMeshProUGUI statusText;


    void Start()
    {
        base.Start();
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
            statusText.text = "Completed! Door Opened";
            OnPuzzleComplete?.Invoke(this);
        }
        Debug.Log(_slicesMade);
    }
    
    void UpdateUI()
    {
        if (sliceCounterText != null)
        {
            if (isCleared)
            {
                sliceCounterText.text = $"Cubes: {requiredSlices}/{requiredSlices}";
            }
            sliceCounterText.text = $"Cubes: {_slicesMade}/{requiredSlices}";
        }
    }
    
}
