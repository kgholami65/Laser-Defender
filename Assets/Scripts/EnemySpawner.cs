using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<WaveConfigSO> waves;
    [SerializeField] private float timeBetweenWaves;
    private WaveConfigSO _currentWave;
    public bool isLooping;
    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        do
            foreach (var wave in waves)
            {
                _currentWave = wave;
                for (int i = 0; i < _currentWave.GetNumberOfEnemies(); i++)
                {
                    yield return new WaitForSecondsRealtime(_currentWave.GetRandomSpawnTimes());
                    Instantiate(enemyPrefab, _currentWave.GetStartingWaypoint().position, Quaternion.identity);
                }

                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        while (isLooping);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return _currentWave;
    }
}
