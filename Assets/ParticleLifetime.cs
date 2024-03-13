using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifetime : MonoBehaviour
{

    [SerializeField] ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyParticle());
    }

    // Update is called once per frame
    IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(particle.main.duration);
        Destroy(this);
        yield return null;
        
    }
}
