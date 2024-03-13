using UnityEngine;

public class PuzzleTriggerBox : PuzzleInteractable
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            OnCleared?.Invoke(this);
        }
    }
}
