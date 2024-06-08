using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("��Start �Լ���: ȣ�� 1");
        StartCoroutine(CoTest());
        SubTest();
        Debug.Log("��Start �Լ���: ȣ�� 2");
    }

    IEnumerator CoTest()
    {
        Debug.Log("��Coroutine �Լ���: ȣ�� 1");
        yield return new WaitForSeconds(1);
        Debug.Log("��Coroutine �Լ���: ȣ�� 2");
        Debug.Log("��Coroutine �Լ���: ȣ�� 3");
    }

    // Subroutine : ���� �帧 �ӿ��� �� ���� ȣ���ϴ� �Լ�. ���������� ����.
    // Coroutine : ���� ������ �Բ� �ϴ� �Լ�. �߰��� ���� �ٸ� �Լ��� ����� �� ����.

    // Coroutine�� Update���� �Ժη� ����ϸ� �� �ȴ�.Update�� 1/60�ʷ� �ݺ��Ǳ� ����


    void SubTest()
    {
        Debug.Log("������ �׽�Ʈ �Լ���: ȣ�� 1");
        Debug.Log("������ �׽�Ʈ �Լ���: ȣ�� 2");
        Debug.Log("������ �׽�Ʈ �Լ���: ȣ�� 3");
    }
}
