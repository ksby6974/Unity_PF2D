using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // ������ �������� ����
    Vector3 offset;             // ī�޶�� �÷��̾��� ��ġ ����
    public Transform playerTransform;   // �÷��̾��� ��ġ(������ ������ ����)
    public float fixedYPosition;        // ī�޶��� Y ��ġ���� ����
    [Range(0f, 1f)]                     // �Ʒ� ������ ũ�⸦ �����ϴ� ����
    public float smoothValue = 0.015f;  // ī�޶��� ���� ����(�ε巯�� ������)�� ���� �� ��ġ ���̿� ��� ���� Percent �̵��� �� ���ΰ�

    // Start is called before the first frame update
    void Start()
    {
        //(GameObject) = �����ͼ� Prefab���� PlayerTransform ��ġ�� �ʿ�
        //playerTransform = transform;

        //transform = camera, ������ ��, ���� -> A - B : B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ
        offset = transform.position - playerTransform.position;

        fixedYPosition = transform.position.y;
    }

    public void setOffset()
    {
        offset = transform.position - playerTransform.position;
    }

    // Lerp. Linear Interpolation ���� ����
    // �� ������ ��, �� �� ������ ������ ��ġ�� ���� �ľ��ϱ� ���� ������ ����
    // �� ��(Point)-(Vector3) ī�޶��� ���� ��ġ. �̵��ϰ� ���� ��ġ, ī�޶� �� Point �� ��ǥ ����

    // �÷��̾��� ������ Update ����� �Ŀ� ī�޶� �ѾƼ� �����̱� ���ؼ�
    // Vector3.Lerp�Լ� ������ �Ǿ��ֽ��ϴ�


    // Update is called once per frame
    void LateUpdate()
    {
        // �÷��̾ ������
        //offset = transform.position - playerTransform.position;

        // ������ �� �������� ī�޶��� ��ġ�� ���Ѵ�.
        // ī�޶��� Y���̸� ������Ų��.
        Vector3 targetPosition = playerTransform.position + offset;
        targetPosition.y = fixedYPosition;

        // ������ ��
        // ������ �÷��̾��� x�������θ� ����ٴϰ�, Y�� ����������
        Vector3 smoothPosition = Vector3.Lerp(new Vector3(transform.position.x, fixedYPosition, transform.position.z), targetPosition, smoothValue);
        transform.position = smoothPosition;
    }
}
