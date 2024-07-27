using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject obj_Player;

    public int spawnCount = 1;    // ��
    public float spawnCycle = 0.4f;     // �ֱ�

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
        // ����Ƽ ���� �ݺ��Լ�
        // ���� : �̹� ������ �Լ��� �������� ������.
        // �߰��� ���ߴ� ������ 1���� ����
        //InvokeRepeating(nameof(CreateEnemyInstance), spawnCycle, 1);
    }

    // Start is called before the first frame update
    private void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    // �ڷ�ƾ�� �߰��� ���ߴ� ������ ������ ����
    IEnumerator SpawnEnemy()
    {
        // ���⿡ ź�� ���� �˸� �߰� ����
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
            float Value = obj_Player.transform.position.x;
            Vector3 spawnPosition = new Vector3(Value, 5, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
