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
            Debug.Log("플레이어가 목표 지점에 도달했습니다.");

            // 화면에 게임을 클리어했습니다. 표시 : UI
            // goaldObject는 반드시 TMP_Text 컴포넌트를 갖고 있다.
            goalObject.SetActive(true);

            if (goalObject.GetComponent<TMP_Text>() != null)
            {
                TMP_Text goalText = goalObject.GetComponent<TMP_Text>();
                goalText.text = "게임 클리어!";
            }

            // 이펙트
        }
    }
}
