using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Trash trash;
    [SerializeField] float z_Spawn_Offset;
    [Tooltip("In Seconds")][SerializeField] float time_Until_Next_Spawn = 1f;
    [SerializeField] float spawn_Radius = 15f;
    private bool isAlive = true;
   // Dictionary<Trash, Vector3> instantitedTrash = new Dictionary<Trash, Vector3>();

    void Start()
    {
        StartCoroutine(SpawnTrash()); // Begins the spawning of trash
        
    }

    void Update()
    {

    }

    IEnumerator SpawnTrash()
    {
        while(isAlive) // Spawns trash while 
        {
            Vector3 spawnPos = GetSpawnPosition();
            Trash spawnedTrash = Instantiate(trash, spawnPos, Quaternion.identity);
           // instantitedTrash.Add(spawnedTrash, spawnPos);
           // foreach(var value in instantitedTrash)
           // {
           //    
           //    
           // }
            yield return new WaitForSeconds(time_Until_Next_Spawn); // wait for time_Until_Next_Spawn and start over again
        }
    }

    private Vector3 GetSpawnPosition() // returns spawn position
    {
        z_Spawn_Offset = Random.Range(-spawn_Radius, spawn_Radius);
        Vector3 spawnerPos = transform.position;
        Vector3 spawnPos = new Vector3(spawnerPos.x, spawnerPos.y, spawnerPos.z + z_Spawn_Offset);
        return spawnPos;
    }


   

}
