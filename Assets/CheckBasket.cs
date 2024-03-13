using UnityEngine;

public class CheckBasket : PuzzleInteractable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            OnCleared?.Invoke(this);
        }
    }
}
