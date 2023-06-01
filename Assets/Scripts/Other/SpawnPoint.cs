using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    [SerializeField] List<GameObject> objectsToSpawn;
    [SerializeField] private bool continuousSpawning = false;
    [SerializeField] private uint spawnDelayInSeconds = 5;

    private bool objectSpawned = false;

    void Update () {
        if(continuousSpawning) {
            if(!objectSpawned) {
                StartCoroutine(SpawnGameObjectCoroutine());
            }
        }
    }

    IEnumerator SpawnGameObjectCoroutine () {
        objectSpawned = true;

        SpawnGameObject();
        yield return new WaitForSeconds(spawnDelayInSeconds);

        objectSpawned = false;
    }
    public void SpawnGameObject () {
        if(objectsToSpawn.Count != 0) {
            int index = (int) Random.Range(0, objectsToSpawn.Count);
            GameObject obj = objectsToSpawn.ElementAt(index);
            Instantiate(obj, transform);
        }
    }
}
