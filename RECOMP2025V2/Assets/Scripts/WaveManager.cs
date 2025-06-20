using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour {
    /* TODO:
     * random spawn locations
     * added health per wave
     */
    // Variables
    public static WaveManager Instance { get; private set; }
    private int waveAmount = 1;
    private bool isWaveCompleted = true;
    [SerializeField] private float timeTillNextWave;
    private float deltaTime;
    [SerializeField] private List<GameObject> enemyPrefabs = new();
    [SerializeField] private List<GameObject> activeEnemies = new();
    
    // Properties
    
    // Methods
    private void Awake() {
        if (Instance != null) {
            Debug.LogError("What the helly?");
        }
        Instance = this;
    }

    private void Update() {
        Timer();
    }

    private void Timer() {
        if (!isWaveCompleted) return;
        deltaTime -= Time.deltaTime;
        if (deltaTime <= 0f) {
            isWaveCompleted = false;
            SpawnWave();
            deltaTime = timeTillNextWave;
        }
    }

    public void CheckEnemyCount() {
        if (!FindObjectOfType<BaseEnemy>()) 
            isWaveCompleted = true;
    } 
    private void SpawnWave() {
        var enemies = GetEnemies(waveAmount);
        foreach (var e in enemies) {
            GameObject t = Instantiate(e.gameObject, GetRandomSpawnPosition(), Quaternion.identity);
            activeEnemies.Add(t);
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
    private Vector2 GetRandomSpawnPosition() {
        return new Vector2(Random.Range(-10f, 10f), 0f);
    }
}