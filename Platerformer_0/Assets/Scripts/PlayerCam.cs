using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // 벡터의 연산으로 구현
    public Transform playerTransform;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //transform = camera, 벡터의 합, 빼기 -> A - B : B에서 출발해서 A까지 이동하는 화살표
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 벡터의 합
        transform.position = playerTransform.position + offset;

        // 플레이어가 움직임
        offset = transform.position - playerTransform.position;
    }
}
