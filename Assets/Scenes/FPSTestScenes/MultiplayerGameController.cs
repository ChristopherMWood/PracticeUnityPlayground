using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums.Multiplayer;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiplayerGameController : MonoBehaviour
{
    [SerializeField]
    InGameMenuScript inGameMenuScript;
    private List<GameObject> SpawnPoints;
    public int EnemiesCount = 4;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    private bool showMenu;

    void Start()
    {
        inGameMenuScript.Close();
        showMenu = false;
        SpawnPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Respawn"));
        SpawnFromPrefab(1, playerPrefab, SpawnGroup.Team2);
        SpawnFromPrefab(EnemiesCount, enemyPrefab, SpawnGroup.Team1);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            showMenu = !showMenu;

            if (showMenu)
            {
                OnOpenSettings();
            }
            else
            {
                OnCloseSettings();
            }
        }
    }

    public void OnOpenSettings()
    {
        inGameMenuScript.Open();
        Debug.Log("Menu Opened");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    
    public void OnCloseSettings()
    {
        inGameMenuScript.Close();
        Debug.Log("Menu Closed");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

    public void QuitGameOnClick()
    {
        Debug.Log("QUIT CLICKED");
        SceneManager.LoadScene("MainMenuScene");
    }
}
