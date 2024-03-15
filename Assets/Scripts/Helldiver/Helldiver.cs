using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Helldiver : PuzzleInteractable
{
    [SerializeField] List<PushButton> _buttonList = new List<PushButton>();

    [SerializeField] List<BTType> _buttonsCode = new List<BTType>();


    private int _codeIndex = 0;
    private void Start()
    {
        foreach (var button in _buttonList)
        {
            button.OnButtonPressed += CheckCode;
        }
    }

    private void CheckCode(BTType type)
    {
        Debug.Log("checking");
        if (type == _buttonsCode[_codeIndex])
        {
            Debug.Log("index");
            _codeIndex++;
            //play sound and animation
        }
        else
        {
            _codeIndex = 0;
            //play sound and animation
        }
        if (_codeIndex == _buttonsCode.Count)
        {
            OnCleared?.Invoke(this);
        }
    }

    private void OnDestroy()
    {
        foreach (var button in _buttonList)
        {
            button.OnButtonPressed -= CheckCode;
        }
    }

}
