using UnityEngine;
using Enums.Multiplayer;

public class SpawnScript : MonoBehaviour
{
    public SpawnGroup spawnGroup = SpawnGroup.Team1;
    private Transform spawnDirectionTransform;
    
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        spawnDirectionTransform = transform.GetChild(0);
    }

    public void Spawn(GameObject prefab) {
        Debug.Log("Spawned enemy");
        var spawnedObject = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y * 2, transform.position.z), Quaternion.identity);

        if (spawnDirectionTransform != null) {
            // spawnedObject.transform.LookAt(spawnDirectionTransform.position, Vector3.up);
            // spawnedObject.transform.LookAt(new Vector3(transform.position.x, spawnDirectionTransform.position.y, transform.position.z));
            // transform.LookAt(Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
    }
}
