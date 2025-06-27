using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour {
    
    // Variables
    public static WaveManager Instance { get; private set; }
    private int waveAmount = 1;
    private int currentWave;
    private int enemiesAlive;
    private bool isWaveCompleted = true;
    private bool isAllowedToStart;
    
    public bool HasStarted => isWaveCompleted;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private float timeTillNextWave;
    [SerializeField] private float deltaTime;
    [SerializeField] private List<GameObject> enemyPrefabs = new();
    
    // Methods
    private void Awake() {
        if (Instance != null) {
            Debug.LogError("What the helly?");
            return;
        }
        Instance = this;
        SetupWaveText();
        UpdateWaveUI();
        deltaTime = timeTillNextWave;
    }
    private void Update() {
        if (!isAllowedToStart || !isWaveCompleted) return;
        Timer();
    }

    private void Timer() {
        deltaTime -= Time.deltaTime;
        if (deltaTime <= 0f) {
            isWaveCompleted = false;
            SpawnWave();
            deltaTime = timeTillNextWave;
        }
    }

    public void CheckEnemyCount() {
        enemiesAlive--;
        if (enemiesAlive <= 0) {
            if (currentWave >= 40f)
                WinGame();
            isWaveCompleted = true;
        }
    } 
    private void SpawnWave() {
        var enemies = GetEnemies(waveAmount);
        foreach (var e in enemies) {
            Instantiate(e.gameObject, GetRandomSpawnPosition(), Quaternion.identity);
        }
        enemiesAlive = enemies.Count;
        waveAmount++;
        currentWave++;
        UpdateWaveUI();
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
        return new Vector2(Random.Range(-8f, 8f), Random.Range(0, 5f));
    }
    public void StartGame() {
        waveText.gameObject.SetActive(true);
        isAllowedToStart = true;
    }

    private void UpdateWaveUI() {
        waveText.text = $"Wave {currentWave}";
    }
    private void SetupWaveText() {
        List<TextMeshProUGUI> texts = new();
        texts = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>().ToList();
        foreach (TextMeshProUGUI t in texts) {
            if (t.CompareTag($"WaveCounter")) {
                waveText = t;
            }
        }
    }

    private void WinGame() {
        SceneManager.LoadScene("WinGame");
    }
    public void ToggleWaveStarter() => isAllowedToStart = !HasStarted;
}