using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Vector3 target;
    public float speed = 5f;

    private void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        Vector3 moveDirection = (new Vector3(target.x, transform.position.y, target.z) - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;

        // Optionally, destroy the object when it gets close enough to the target
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.x, 0, target.z)) < 1f)
        {
            Destroy(gameObject);
        }
    }
}