using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ��û ū ��
// ���� ������ ���� ƨ���
// �ٷ� ���� �Ӹ� ������
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