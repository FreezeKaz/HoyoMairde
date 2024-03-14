using System;
using UnityEngine;

public enum BTType
{
    UP, DOWN, LEFT, RIGHT
}

public class PushButton : MonoBehaviour
{
    public Action<BTType> OnButtonPressed;
    public BTType type;
}
