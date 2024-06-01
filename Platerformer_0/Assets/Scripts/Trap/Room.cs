using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject GasObject;
    private int PlayerHP = 100000;
    private int Damage = 1;
    public bool isGasState = false;
    public bool isStayOn = false;
    public float checkTime = 2f;
    public float Timer = 0;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Player가 알아야 할 필요성이 있음
            //PlayerController <- 다른 클래스에서 나의 클래스를 어떻게 접근?
            Damage = 0; 
            isGasState = true;
            Debug.Log($"Player와 접촉 시작 (Enter) : {isGasState}");

            GasObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Player가 알아야 할 필요성이 있음
            //PlayerController <- 다른 클래스에서 나의 클래스를 어떻게 접근?
            isGasState = false;
            Debug.Log($"Player가 벗어남 (Exit) : {isGasState}");

            GasObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isStayOn)
        {
            //Debug.Log($"Player가 접촉중 (Stay)");
        }
    }

    private void Update()
    {
        if (isGasState)
        {
            Timer += Time.deltaTime;    // 0.016f (컴퓨터마다 차이 있음)

            if (Timer >= checkTime)
            {
                Timer = 0;
                PlayerHP = PlayerHP - Damage;
                Debug.Log($"현재 PlayerHp ({PlayerHP})");
            }
        }
    }
}
