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
    [SerializeField] private AudioSource _audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            OnButtonPressed?.Invoke(type);
            if(_audio != null)  _audio.Play();
        }
    }
}
