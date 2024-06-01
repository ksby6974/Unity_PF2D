using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject goalObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ��ǥ ������ �����߽��ϴ�.");

            // ȭ�鿡 ������ Ŭ�����߽��ϴ�. ǥ�� : UI
            // goaldObject�� �ݵ�� TMP_Text ������Ʈ�� ���� �ִ�.
            goalObject.SetActive(true);

            if (goalObject.GetComponent<TMP_Text>() != null)
            {
                TMP_Text goalText = goalObject.GetComponent<TMP_Text>();
                goalText.text = "���� Ŭ����!";
            }

            // ����Ʈ
        }
    }
}
