using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timebetweenWaves = 5f;

    private float countdown = 2f;

    public Text waveCountdownText;


    private int waveIndex = 0;
    private void Update()
    {
        if (countdown<=0f)
        {
            StartCoroutine( SpawnWave());
            countdown = timebetweenWaves;

        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Math.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
