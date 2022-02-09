using UnityEngine;
using Enums.Multiplayer;

public class SpawnScript : MonoBehaviour
{
    public SpawnGroup spawnGroup = SpawnGroup.Team1;
    
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;

        foreach (Transform child in transform)
            child.GetComponent<MeshRenderer>().enabled = false;
    }

    public void Spawn(GameObject prefab) {
        var spawnedObject = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y * 2, transform.position.z), Quaternion.identity);
        spawnedObject.transform.rotation = transform.rotation;
    }
}
