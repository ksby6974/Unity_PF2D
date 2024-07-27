using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 엄청 큰 거
// 땅에 닿으면 위로 튕기기
// 바로 유저 머리 위에서
// 



public class Pattern00 : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDirection;
    private float originSpeed;

    private void Awake()
    {
        originSpeed = moveSpeed;
    }

    public float MoveSpeed(float modify)
    {
        moveSpeed += modify;

        return moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}