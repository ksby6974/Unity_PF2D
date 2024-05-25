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
        // 생성할 프리팹, 생성할 위치 (Vector)
        // 디폴트 prefab의 위치는 기존 위치, 회전값으로 생성됨
        Instantiate(prefab, spawnPosition.position, Quaternion.identity); ; //Quaternion.identity:Prefab이 가지고 있는 각도로 생성하라.


    }

    // Update is called once per frame
    void Update()
    {
        // 조건에 따라서 프리팹이 생성되는 것
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
