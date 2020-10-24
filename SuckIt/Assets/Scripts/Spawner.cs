using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class Spawner : MonoBehaviour
{
    [SerializeField] Trash trashPrefab;
    Trash spawnedTrash;
    [SerializeField] float z_Spawn_Offset;
    [SerializeField] float spawn_Radius = 15f;


    [Tooltip("In Seconds")] [SerializeField] float time_Until_Next_Spawn = 1f;
    [SerializeField] float time_At_Spawner_Speed_Up = 30f;
    [SerializeField] float time_Increment = 10f;
    // [SerializeField] float timeBeforeNextSpeedUp = 15f;
    // [SerializeField] float timeIncrement = 15f;

    Scoreboard scoreboard;

    private void Awake()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
    }
    void Start()
    {
        StartCoroutine(SpawnTrash()); // Begins the spawning of trash
        
    }

    void Update()
    {
        ProcessTimeEvents();
    }

   private void ProcessTimeEvents()
   {
      if(time_Until_Next_Spawn <= .20f) { return; }
      if(Time.time >= time_At_Spawner_Speed_Up) { time_Until_Next_Spawn -= 0.08f; time_At_Spawner_Speed_Up += time_Increment; }
   }

    IEnumerator SpawnTrash()
    {
        while(scoreboard.isAlive) // Spawns trash while the player is alive
        {
            Vector3 spawnPos = GetSpawnPosition();
            spawnedTrash = Instantiate(trashPrefab, spawnPos, Quaternion.identity);
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
