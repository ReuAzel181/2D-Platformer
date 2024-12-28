using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;

    [SerializeField] private Transform[] levelPrefabs;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;

    private void Start()
    {
        lastEndPosition = Vector3.zero; // Set initial position

        // Spawn initial platform
        SpawnLevelPart();
    }

    private void Update()
    {
        // Check if player is near the edge to spawn a new platform
        if (Vector3.Distance(player.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        // Generate a random index to select a level prefab
        int randomIndex = Random.Range(0, levelPrefabs.Length);

        // Spawn the selected level prefab at the last end position
        Transform lastLevelPart = Instantiate(levelPrefabs[randomIndex], lastEndPosition, Quaternion.identity);

        // Debug positions
        Debug.Log($"Spawned at: {lastEndPosition}");
        Vector3 endPPosition = lastLevelPart.Find("EndP")?.position ?? Vector3.zero;
        Debug.Log($"EndP Position: {endPPosition}");

        // Update the last end position to the end point of the spawned platform
        lastEndPosition = endPPosition;

        // Optional: Adjust based on tile size if needed
        // lastEndPosition = endPPosition + new Vector3(0, 0, PLAYER_DISTANCE_SPAWN_LEVEL_PART);
    }

    // Visualize positions in the Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(lastEndPosition, lastEndPosition + new Vector3(0, 0, PLAYER_DISTANCE_SPAWN_LEVEL_PART));
    }
}
