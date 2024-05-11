using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // ������ �������� ����
    public Transform playerTransform;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //transform = camera, ������ ��, ���� -> A - B : B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ��
        transform.position = playerTransform.position + offset;

        // �÷��̾ ������
        offset = transform.position - playerTransform.position;
    }
}
