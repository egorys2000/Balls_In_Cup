using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject instance;

    private List<GameObject> Pool = new List<GameObject>();

    [SerializeField]
    private float 
        SpawnPeriod = .2f, 
        SpawnPeriodError = .2f; // < 1

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (Pool.Count < GameManager.Get().MaxBalls) 
        {
            var newborn = Instantiate(instance, transform);

            newborn.transform.localPosition = Vector3.zero;

            Pool.Add(newborn);

            float wait_for = SpawnPeriod + 2 * Random.Range(0, SpawnPeriod * SpawnPeriodError) - SpawnPeriod * SpawnPeriodError;
            yield return new WaitForSeconds(wait_for);
        }
    }
}
