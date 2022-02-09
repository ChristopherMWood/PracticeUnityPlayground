using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums.Multiplayer;

public class MultiplayerGameController : MonoBehaviour
{
    private List<GameObject> SpawnPoints;
    public int EnemiesCount = 4;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    void Start()
    {
        SpawnPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Respawn"));
        SpawnFromPrefab(1, playerPrefab, SpawnGroup.Team2);
        SpawnFromPrefab(EnemiesCount, enemyPrefab, SpawnGroup.Team1);
    }

    public void SpawnFromPrefab(int spawnCount, GameObject prefab, SpawnGroup group) 
    {
        var remainingToSpawn = spawnCount;

        foreach (var spawnPoint in SpawnPoints) {
            if (remainingToSpawn <= 0) {
                return;
            }

            var spawnScript = spawnPoint.GetComponent<SpawnScript>();

            if (spawnScript.spawnGroup == group) {
                spawnScript.Spawn(prefab);
                remainingToSpawn--;
            }
        }
    }
}
