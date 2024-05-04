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
    public float moveSpeed = 16f;    // 캐릭터 이동 속도
    public float JumpForce = 12f;   // 캐릭터 점프
    private float moveInput;        // 캐릭터의 방향 및 인풋 데이터 저장

    public Transform startTransform;    // 캐릭터가 시작할 위치 저장
    public Rigidbody2D rigidbody2D;     // 물리(강체) 기능을 제어하는 컴포넌트 

    [Header("Jump")]
    public bool isGrounded;      // 캐릭터가 점프할 수 있는 상태
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log($"Start 확인했습니다.");
        // 현재 내 위취 <= 새로운 x,y 저장하는 데이터 타입
        //transform.position = new Vector2(transform.position.x, 10);
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1프레임마다 반복적으로 호출
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);

        // 플레이어의 입력값 받기
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);

        //스페이스 키를 입력 시 실행
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // 점프 : Y position _ rigidbody Y velocity를 점프 파워만큼
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}
