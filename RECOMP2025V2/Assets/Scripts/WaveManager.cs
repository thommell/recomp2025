using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour {
    
    
    /* TODO:
     * Enemy list of prefabs
     * random spawn locations
     * added health per wave
     * randomized enemy spawning
     */
    // Variables
    private int waveAmount;
    private int currentEnemyAmount = 0;
    [SerializeField] private List<GameObject> enemyPrefabs = new();
    
    // Properties
    
    // Methods
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnWave();
    }
    private void SpawnWave() {
        var enemies = GetEnemies(waveAmount);
        foreach (var e in enemies) {
            Instantiate(e.gameObject, e.transform.position, Quaternion.identity);
        }
        waveAmount++;
    }
    private List<GameObject> GetEnemies(int pEnemyAmount) {
        List<GameObject> enemiesToSpawn = new();
        for (int i = 0; i < pEnemyAmount; i++) {
            enemiesToSpawn.Add(GetRandomEnemy());
        }
        return enemiesToSpawn;
    }
    private GameObject GetRandomEnemy() {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        for (int i = 0; i < enemyPrefabs.Count; i++) {
            if (randomIndex == i)
                return enemyPrefabs[i];
        }
        return null;
    }
}