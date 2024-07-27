using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //
    public SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    new Rigidbody2D rigidbody2D;
    //public PlayerUI playerUI;

    void LoadComponent()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

       // playerUI = FindObjectOfType<PlayerUI>;
    }

    private void Awake()
    {
        LoadComponent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 플레이어가 죽었다.
            // 체력이 0일 때 게임을 메인 메뉴로 갈지 종료할 지 선택하는 UI
            //LoadMainMenu();

            Player_MainMove player = collision.GetComponent<Player_MainMove>();

            // 플레이어 체력 로직
            if (player.currentHp > 0)
            {
                player.currentHp = player.currentHp - 1;
            }

            Debug.Log($"{collision.gameObject.name} 체력감소:{player.currentHp}");
            if (player.currentHp <= 0)
            {
                MainController.instance.GameQuit();
            }
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {

    }
}
