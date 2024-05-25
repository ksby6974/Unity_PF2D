using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_test : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition; 

    // Start is called before the first frame update
    void Start()
    {
        // ������ ������, ������ ��ġ (Vector)
        // ����Ʈ prefab�� ��ġ�� ���� ��ġ, ȸ�������� ������
        Instantiate(prefab, spawnPosition.position, Quaternion.identity); ; //Quaternion.identity:Prefab�� ������ �ִ� ������ �����϶�.


    }

    // Update is called once per frame
    void Update()
    {
        // ���ǿ� ���� �������� �����Ǵ� ��
        if(Input.GetKeyDown(KeyCode.S))
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        Instantiate(prefab, spawnPosition.position, Quaternion.identity);
    }
}
