using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern02 : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int spawnCount = 1;    // 수
    public float spawnCycle = 0.4f;     // 주기

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
        // 유니티 제공 반복함수
        // 단점 : 이미 정해진 함수라 유연성이 부족함.
        // 중간에 멈추는 행위를 1번만 가능
        //InvokeRepeating(nameof(CreateEnemyInstance), spawnCycle, 1);
    }

    // Start is called before the first frame update
    private void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    // 코루틴은 중간에 멈추는 행위를 여러번 가능
    IEnumerator SpawnEnemy()
    {
        // 여기에 탄막 전조 알림 추가 가능
        //yield return new WaitForSeconds(spawnCycle);

        int repeatTime = 1;
        for (int i = 0; i < repeatTime; i++)
        {
            CreateEnemyInstance(spawnCount);

            yield return new WaitForSeconds(spawnCycle);
        }

        gameObject.SetActive(false);
    }

    private void CreateEnemyInstance(int count)
    {
        spawnCount = 1;

        for (int i = 0; i < spawnCount; i++)
        {
            float randomValue = Random.Range(-8, 8);
            Vector3 spawnPosition = new Vector3(randomValue, 5, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
