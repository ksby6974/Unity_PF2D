using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_MainMove : MonoBehaviour
{
    //����Ƽ�� ���س��� ���� �ð��� Start�Լ��� Update�Լ��� ����
    // Start is called before the first frame update
    // ù �������� ȣ��Ǳ� �� �� �� �� �����ϴ� �Լ�

    //�ӵ�, ����
    [Header("Move_Input")]
    public float moveSpeed = 12f;    // ĳ���� �̵� �ӵ�
    public float JumpForce = 8f;   // ĳ���� ����
    private float moveInput;        // ĳ������ ���� �� ��ǲ ������ ����

    //public Transform startTransform;    // ĳ���Ͱ� ������ ��ġ ����
    public Rigidbody2D rigidbody2D;     // ����(��ü) ����� �����ϴ� ������Ʈ 

    [Header("Jump")]
    public bool isGrounded;      // ĳ���Ͱ� ������ �� �ִ� ����
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    [Header("Flip")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDirection = 1;

    public Animator animator;
    private bool isMove;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log($"Player Control Start");
        InitialPlayerStatus();
    }

    // Update is called once per frame
    // 1�����Ӹ��� �ݺ������� ȣ��
    void Update()
    {
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        PlayerMove();
        FallDownCheck();
    }

    /// <summary>
    /// ����
    /// </summary>
    private void FallDownCheck()
    {
        // y�� ���̰� Ư�� �������� ���� �� ������ ������ ���� -> ������ �浹 üũ ��ü
        if(transform.position.y < -11)
        {
            InitialPlayerStatus();
        }
    }

    void InitialPlayerStatus()
    {
        // ���� �� ��ġ <= ���ο� x,y �����ϴ� ������ Ÿ��
        //transform.position = new Vector2(transform.position.x, 10);
        //transform.position = startTransform.position;
        rigidbody2D.velocity = Vector2.zero;
        facingRight = true;
        spriteRenderer.flipX = false;
    }

    /// <summary>
    /// �ִϸ��̼� ����
    /// </summary>
    private void HandleAnimation()
    {
        //�� ����, ����������

        // rigidbody.velocity : ���� rigibody�� �ӵ� "= 0" = �������� ����
        isMove = rigidbody2D.velocity.x != 0;
        animator.SetBool("isMove",isMove);
        animator.SetBool("isGrounded", isGrounded);

        // SetFloat �Լ��� ���ؼ� y�ִ��� �� 1�� ��ȯ, y �ּ��� �� -1�� ��ȯ
        // ���� Ű�� ������, ���������� y ���� ����, ���� �߷¿� ���ؼ� y �ӵ� -���� �������ϴ�.
        animator.SetFloat("yVelocity",rigidbody2D.velocity.y);
    }

    /// <summary>
    /// ���� �� ���ΰ� �ƴѰ� üũ -> Collider Check
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
    }

    /// <summary>
    /// �÷��̾� �Է��� ����
    /// </summary>
    private void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        JumpButton();

        Debug.Log($"THIS : {isGrounded}");
    }

    private void HandleFlip()
    {
        //���������� ������ �ٶ󺸰� ���� ��
        if (facingRight && moveInput < 0)
        {
            Flip();
        }
        //�������� ������ �ٶ󺸰� ���� ��
        else if (!facingRight && moveInput > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }

    private void JumpButton()
    {
        //�����̽� Ű�� �Է� �� ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // ���� : Y position _ rigidbody Y velocity�� ���� �Ŀ���ŭ
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
    }

    private void PlayerMove()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}
