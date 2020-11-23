using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

[DisallowMultipleComponent]
public class Spawner : MonoBehaviour
{
    #region Variables
    [SerializeField] Trash trashPrefab = null;
    [SerializeField] float z_Spawn_Offset;
    [SerializeField] float spawn_Radius = 15f;


    [Tooltip("In Seconds")] [SerializeField] float time_Until_Next_Spawn = 1f;
    [SerializeField] float time_At_Spawner_Speed_Up = 30f;
    [SerializeField] float time_Increment = 10f;
    //[SerializeField] float timeBeforeNextSpeedUp = 15f;
    //[SerializeField] float timeIncrement = 15f;

    [SerializeField] Core core = null;
    [SerializeField] CountdownTimer countdownTimer;
    #endregion

    void Start()
    {
        StartCoroutine(SpawnTrash()); // Begins the spawning of trash 
        countdownTimer.OnCountdownFinished += CountdownTimer_OnCountdownFinished;
    }

    private void CountdownTimer_OnCountdownFinished(object sender, CountdownTimer.OnCountdownFinishedEventArgs e)
    {
        if (e.startSpawning == true)
        {
            StartCoroutine(SpawnTrash());
        }
    }

    void Update()
    {
        ProcessTimeEvents();
    }

    private void ProcessTimeEvents()
    {
       if(time_Until_Next_Spawn <= .20f) { return; }
       if(Time.time >= time_At_Spawner_Speed_Up) { time_Until_Next_Spawn -= 0.08f; time_At_Spawner_Speed_Up += time_Increment; }
       //if (Time.time >= timeAtNextSpawn) { timeAtNextSpawn += timeIncrement; movingSpeedFactor += .015f; }
    }

    public IEnumerator SpawnTrash()
    {
        while(core.isAlive) // Spawns trash while the player is alive
        {
            Vector3 spawnPos = GetSpawnPosition();
            Instantiate(trashPrefab, spawnPos, Quaternion.identity);
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

    private void OnDestroy() // Safety code
    {
        countdownTimer.OnCountdownFinished -= CountdownTimer_OnCountdownFinished; // Unsubscribe if destroyed
    }


}
