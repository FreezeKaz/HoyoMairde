using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzle : MonoBehaviour
{

    [SerializeField] float _speed = 25;

    private void Update()
    {
        transform.Rotate(new Vector3(1,0,0), _speed * Time.deltaTime);
    }
}
