using UnityEngine;

public class CheckBasket : PuzzleInteractable
{
    [SerializeField] GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Ball"))
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            OnCleared?.Invoke(this);
        }
    }
}
