using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState {
        SPAWNING, WAITING, COUNTING
    }

    [System.Serializable]
    public class Wave {
        public string name;
        public Transform[] enemy;
        public int[] count;
    }
    
    public Wave[] waves;
    private int nextWave = 0;

    public int minX, maxX, minY, maxY;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start() {
        waveCountdown = timeBetweenWaves;
    }

    void Update() {
        if (state == SpawnState.WAITING) {
            if (!EnemyIsAlive()) {
                
                Debug.Log("Wave Completed");
            }
            else return;
        }

        if (waveCountdown <= 0) {
            if (state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else waveCountdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave(Wave _wave) {
        float rate = 0f; 
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count.Length; i++) {
            rate += _wave.count[i];
        }

        for (int i = 0; i < _wave.count.Length; i++) {
            for (int j = 0; j < _wave.count[i]; j++) {
                SpawnEnemy(_wave.enemy[i]);
                yield return new WaitForSeconds(1f/rate);
            }
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy) {
        Debug.Log(_enemy.transform.position);
        _enemy.transform.position = new Vector3(Random.Range(minX,maxX), Random.Range(minY,maxY), 0f);
        Debug.Log(_enemy.transform.position);
        Instantiate(_enemy, _enemy.transform.position, Quaternion.identity);
    }

    bool EnemyIsAlive() {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown > 0) return true;

        searchCountdown = 1f;
        if (GameObject.FindGameObjectWithTag("Enemy") == null) return false;

        return true;
    }
}
