using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
 
public class RupeeManager : MonoBehaviour
{
    public Transform spawner;
    public Rupee prefab;
    public Transform container;
    public float spawnDelay = 2f;
    private readonly List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnRoutine;
    public event Action<Rupee> OnCollected;
 
    private void Start()
    {
        StartSpawning();
    }
 
    public void StartSpawning()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }
   
    private void Spawn()
    {
        var rupee = Instantiate(prefab, spawner.position, Quaternion.identity);
        rupee.transform.parent = container;
        AddRupee(rupee);
    }
 
    private IEnumerator SpawnRoutine()
    {
        Spawn();
        yield return new WaitForSeconds(spawnDelay);
        StartSpawning();
    }

    private void AddRupee(Rupee rupee)
    {
        rupee.OnCollected += RupeeCollectedHandler;
        _rupees.Add(rupee);
        //Debug.Log(_rupees.Count);
    }

    private void RemoveRupee(Rupee rupee)
    {
        rupee.OnCollected -= RupeeCollectedHandler;
        _rupees.Remove(rupee);
        //Debug.Log(_rupees.Count);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        OnCollected?.Invoke(rupee);
        RemoveRupee(rupee);
    }
}