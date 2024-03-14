using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject leftObjectToSpawn; // Assign prefab for the left object
    public GameObject rightObjectToSpawn; // Assign prefab for the right object
    public float spawnInterval = 3f;
    public Vector2 lateralSpawnRange = new Vector2(-1f, 1f); // Range for lateral variation
    public Vector2 heightSpawnRange = new Vector2(-1f, 1f); // Range for random height variation
    public Transform playerTransform; // Reference to the player or target position
    public float spawnDistance = 10f; // Distance in front of the player where objects spawn

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime; // Increment timer by the time passed since last frame

        if (timer >= spawnInterval) // Check if the timer reached the current spawn interval
        {
            SpawnObjects(); // Spawn objects
            timer = 0; // Reset the timer

            // Immediately determine the next spawn interval randomly
            spawnInterval = Random.Range(1, 2);
        }
    }   

    void SpawnObjects()
    {
        // Calculate base spawn position directly in front of the player
        Vector3 baseSpawnPos = playerTransform.position + playerTransform.forward * spawnDistance;

        // Randomize height within the specified range
        float randomHeightLeft = Random.Range(heightSpawnRange.x, heightSpawnRange.y);
        float randomHeightRight = Random.Range(heightSpawnRange.x, heightSpawnRange.y);

        // Apply lateral and vertical (height) adjustments
        Vector3 leftSpawnPos = baseSpawnPos + playerTransform.right * lateralSpawnRange.x + new Vector3(0, randomHeightLeft, 0);
        Vector3 rightSpawnPos = baseSpawnPos + playerTransform.right * lateralSpawnRange.y + new Vector3(0, randomHeightRight, 0);

        // Instantiate both objects
        SpawnObject(leftObjectToSpawn, leftSpawnPos);
        SpawnObject(rightObjectToSpawn, rightSpawnPos);
    }

    void SpawnObject(GameObject objectToSpawn, Vector3 spawnPos)
    {
        GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        MovableObject movableObject = obj.AddComponent<MovableObject>(); // Ensure the prefab has no MovableObject component pre-attached
        movableObject.target = new Vector3(playerTransform.position.x, spawnPos.y, playerTransform.position.z); // Set target maintaining height
        movableObject.speed = 5f; // Set speed or adjust as necessary
    }
}
