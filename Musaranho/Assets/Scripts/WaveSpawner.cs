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
    private int nextWave = -1;

    public int minX, maxX, minY, maxY;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.WAITING;

    void Start() {
        waveCountdown = timeBetweenWaves;
    }

    void Update() {
        if (nextWave == -99) return;

        if (state == SpawnState.WAITING) {
            if (!EnemyIsAlive()) {
                WaveCompleted();
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

    void WaveCompleted() {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) End();
        else nextWave++;
    }

    void End() {
        nextWave = -99;
        Debug.Log("All waves completed");
    }

    void SpawnEnemy(Transform _enemy) {
        _enemy.transform.position = new Vector3(Random.Range(minX,maxX), Random.Range(minY,maxY), 0f);
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
