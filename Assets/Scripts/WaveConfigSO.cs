using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
   [SerializeField] private float movementSpeed;
   [SerializeField] private Transform pathPrefab; //how is it working in the game when it doesnt know if the prefab exists in scene
   [SerializeField] private int numberOfEnemies;
   [SerializeField] private float spawnTimeVariance;
   [SerializeField] private float timeBetweenSpawns;
   [SerializeField] private float minimumSpawnTime;

   public float GetMovementSpeed()
   {
      return movementSpeed;
   }

   public List<Transform> GetWaypoints()
   {
      var waves = new List<Transform>();
      
      foreach (Transform child in pathPrefab) //wtf
         waves.Add(child);

      return waves;
   }

   public Transform GetStartingWaypoint()
   {
      return pathPrefab.GetChild(0);
   }

   public int GetNumberOfEnemies()
   {
      return numberOfEnemies;
   }

   public float GetRandomSpawnTimes()
   {
      var randomSpawnTime = Random.Range(timeBetweenSpawns - spawnTimeVariance, timeBetweenSpawns + spawnTimeVariance);
      return Mathf.Clamp(randomSpawnTime, minimumSpawnTime, float.MaxValue);
   }
}
