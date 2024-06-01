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
            //Player�� �˾ƾ� �� �ʿ伺�� ����
            //PlayerController <- �ٸ� Ŭ�������� ���� Ŭ������ ��� ����?
            Damage = 0; 
            isGasState = true;
            Debug.Log($"Player�� ���� ���� (Enter) : {isGasState}");

            GasObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Player�� �˾ƾ� �� �ʿ伺�� ����
            //PlayerController <- �ٸ� Ŭ�������� ���� Ŭ������ ��� ����?
            isGasState = false;
            Debug.Log($"Player�� ��� (Exit) : {isGasState}");

            GasObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isStayOn)
        {
            //Debug.Log($"Player�� ������ (Stay)");
        }
    }

    private void Update()
    {
        if (isGasState)
        {
            Timer += Time.deltaTime;    // 0.016f (��ǻ�͸��� ���� ����)

            if (Timer >= checkTime)
            {
                Timer = 0;
                PlayerHP = PlayerHP - Damage;
                Debug.Log($"���� PlayerHp ({PlayerHP})");
            }
        }
    }
}
