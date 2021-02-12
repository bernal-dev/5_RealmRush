using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int amountOfEnemies = 5;
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] private EnemyMovement enemy;

    private void Start()
    {
        var pathFinder = FindObjectOfType<PathFinder>();
        transform.position = pathFinder.startWaypoint.transform.position;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies ()
    {
        while (amountOfEnemies-- > 0)
        {
            Instantiate(enemy, transform);
            yield return new WaitForSecondsRealtime(secondsBetweenSpawns);
        }
    }

}