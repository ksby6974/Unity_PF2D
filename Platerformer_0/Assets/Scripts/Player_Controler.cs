using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_MainMove : MonoBehaviour
{
    //유니티가 정해놓은 실행 시간에 Start함수와 Update함수가 시작
    // Start is called before the first frame update
    // 첫 프레임이 호출되기 전 단 한 번 실행하는 함수

    //속도, 방향
    [Header("Move_Input")]
    public float moveSpeed = 12f;    // 캐릭터 이동 속도
    public float JumpForce = 8f;   // 캐릭터 점프
    private float moveInput;        // 캐릭터의 방향 및 인풋 데이터 저장

    //public Transform startTransform;    // 캐릭터가 시작할 위치 저장
    public Rigidbody2D rigidbody2D;     // 물리(강체) 기능을 제어하는 컴포넌트 

    [Header("Jump")]
    public bool isGrounded;      // 캐릭터가 점프할 수 있는 상태
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
    // 1프레임마다 반복적으로 호출
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
    /// 낙사
    /// </summary>
    private void FallDownCheck()
    {
        // y의 높이가 특정 지점보다 낮을 때 낙사한 것으로 간주 -> 다음에 충돌 체크 대체
        if(transform.position.y < -11)
        {
            InitialPlayerStatus();
        }
    }

    void InitialPlayerStatus()
    {
        // 현재 내 위치 <= 새로운 x,y 저장하는 데이터 타입
        //transform.position = new Vector2(transform.position.x, 10);
        //transform.position = startTransform.position;
        rigidbody2D.velocity = Vector2.zero;
        facingRight = true;
        spriteRenderer.flipX = false;
    }

    /// <summary>
    /// 애니메이션 관리
    /// </summary>
    private void HandleAnimation()
    {
        //값 세팅, 연동시켜줌

        // rigidbody.velocity : 현재 rigibody의 속도 "= 0" = 움직이지 않음
        isMove = rigidbody2D.velocity.x != 0;
        animator.SetBool("isMove",isMove);
        animator.SetBool("isGrounded", isGrounded);

        // SetFloat 함수에 의해서 y최대일 때 1로 변환, y 최소일 때 -1로 변환
        // 점프 키를 누르면, 순간적으로 y 높이 증가, 점점 중력에 의해서 y 속도 -까지 내려갑니다.
        animator.SetFloat("yVelocity",rigidbody2D.velocity.y);
    }

    /// <summary>
    /// 점프 시 땅인가 아닌가 체크 -> Collider Check
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
    }

    /// <summary>
    /// 플레이어 입력을 받음
    /// </summary>
    private void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        JumpButton();

        Debug.Log($"THIS : {isGrounded}");
    }

    private void HandleFlip()
    {
        //오른쪽으로 방향을 바라보고 있을 때
        if (facingRight && moveInput < 0)
        {
            Flip();
        }
        //왼쪽으로 방향을 바라보고 있을 때
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
        //스페이스 키를 입력 시 실행
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // 점프 : Y position _ rigidbody Y velocity를 점프 파워만큼
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
