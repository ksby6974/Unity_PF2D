using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �浹�ϱ� ���ؼ��� �� ��ü �� �� ��ü�� Rigidbody(2D)�� ������Ʈ�� �����ʿ�
// �� ��ü ���� �� Collider�� ���� �־�� �Ѵ�.
// �÷��̾�� �浹�ϸ� �浹���� ������ �̺�Ʈ �۵��Ѵ�
public class Trap: MonoBehaviour
{
    // �浹 �̺�Ʈ�� �ۼ��� �� ��� ������Ʈ�� ������� �ۼ��� ���� ���� ����
    // �������� �鿡���� ��ȿ����
    // �浹 �̺�Ʈ�� Ư�� ��� �۵��ϵ��� �±׸� ���� (���� ������Ʈ �Ѱ��� �±� ����)

    // Tag - ������ �浹 �̺�Ʈ���� ���
    // Layer - �̺�Ʈ�� �۵��� �� Ư�� ��� �з����ִ� ����, �� ������Ʈ�� ���� ���� ���̾� ���� ����
    // Collider 2D

    protected bool isWorking = false;

    // Collider 2D�̰� Higidbody2D���� ��.
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾� �±� ���� ���� �˻�
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player ���� �ǰ� (collision �浹)");
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        // �÷��̾� �±� ���� ���� �˻�
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player ���� �ǰ� (trigger �浹)");
        }
    }
}
