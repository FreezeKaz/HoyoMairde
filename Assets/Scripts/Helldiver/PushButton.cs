using System;
using UnityEngine;

public enum BTType
{
    UP, DOWN, LEFT, RIGHT
}

public class PushButton : MonoBehaviour
{
    public Action<BTType> OnButtonHold;
    public Action<BTType> OnButtonPressed;
    public BTType type;
    [SerializeField] private AudioSource _audio;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("button pressed");
            OnButtonHold?.Invoke(type);
            if (_audio != null) _audio.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("button pressed");
            OnButtonPressed?.Invoke(type);
            if (_audio != null) _audio.Play();
        }
    }
}
