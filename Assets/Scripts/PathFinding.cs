
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private WaveConfigSO _waveConfig;
    private List<Transform> _waypoints;
    private int _waypointIndex;

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        InitializeFields();
    }
    
    
    void Update() {
        FollowPath();
    }

    private void InitializeFields()
    {
        _waveConfig = _enemySpawner.GetCurrentWave();
        _waypoints = _waveConfig.GetWaypoints();
        transform.position = _waveConfig.GetStartingWaypoint().position;
        _waypointIndex = 0;
    }

    private void FollowPath() {
        
        if (_waypointIndex < _waypoints.Count)
        {
            Vector3 target = _waypoints[_waypointIndex].position;
            if (transform.position == target)
            {
                _waypointIndex++;
                return;
            }
            var speed = _waveConfig.GetMovementSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, speed);
        }
        else
            Destroy(gameObject);
    }
}
