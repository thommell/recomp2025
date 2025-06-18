using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyFactory : MonoBehaviour {
    // Variables
    private static EnemyFactory instance;
    [SerializeField] private List<GameObject> enemyPrefabs = new(); 
    
    // Properties
    public static EnemyFactory Instance => instance;

    private void Start() {
        // initialize a new instance
        if (!instance) 
            instance = this;
    }

    private GameObject CreateEnemy() {
        GameObject newEnemy = GetRandomPrefab();
        newEnemy.GetComponent<Transform>().localPosition = SetPosition();
        
        Vector2 SetPosition() {
            return new Vector2(Random.Range(-1.0f, 1.0f), 0f);
        }

        return newEnemy;
    }

    private GameObject GetRandomPrefab() {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        for (int i = 0; i < enemyPrefabs.Count; i++) {
            if (randomIndex == i) {
                return enemyPrefabs[i];
            }
        }
        throw new IndexOutOfRangeException();
    }
}