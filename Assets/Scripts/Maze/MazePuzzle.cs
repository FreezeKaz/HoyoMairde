using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzle : MonoBehaviour
{
    [SerializeField] private float _speed = 25;
    [SerializeField] private PushButton _pushButtonRight;
    [SerializeField] private PushButton _pushButtonLeft;

    private void Start()
    {
        _pushButtonLeft.OnButtonPressed += Turn;
        _pushButtonRight.OnButtonPressed += Turn;
    }

    private void Turn(BTType type)
    {
        switch (type)
        {
            case BTType.LEFT:
                transform.Rotate(new Vector3(1, 0, 0), _speed * Time.deltaTime);
                break;
            case BTType.RIGHT:
                transform.Rotate(new Vector3(1, 0, 0), -_speed * Time.deltaTime);
                break;
        }
    }

    private void OnDestroy()
    {
        _pushButtonLeft.OnButtonPressed -= Turn;
        _pushButtonRight.OnButtonPressed -= Turn;
    }
}
