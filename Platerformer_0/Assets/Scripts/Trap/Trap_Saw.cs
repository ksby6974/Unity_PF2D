using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;     //톱니바퀴가 이동할 위치를 저장할 변수
    public float speed = 5f;
    public int moveindex = 0;
    public bool OnGoing = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isWorking = true;
    }

    private void Update()
    {
        anim.SetBool("isWorking",isWorking);
        MoveTrap();
    }

    private void MoveTrap()
    {
        // 프레임은 컴퓨터 환경에 따라 다르기 때문에
        // Time.deltaTime로 맞춰준다
        // 보통 평균으로 0.0016의 값
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveindex].position, speed * Time.deltaTime);

        // 함정이 목표한 지점까지 도착했는가
        if (Vector3.Distance(transform.position, movePositions[moveindex].position) <= 0.1f)
        {
            if (moveindex == 0)
            {
                OnGoing = true;
            }

            if (OnGoing == true)
            {
                moveindex += 1;
            }
            else
            {
                moveindex -= 1;
            }

            if (movePositions.Length <= moveindex)
            {
                moveindex = movePositions.Length -1;
                OnGoing = false;
            }

            // 다음 목표 지점으로 변경
            // 다음 목표 지점이 없으면 0으로 초기화
        }
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 태그 보유 여부 검사
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player 함정 피격 (collision 충돌)");
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        // 플레이어 태그 보유 여부 검사
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player 함정 피격 (trigger 충돌)");

            //플레이어 파괴
            Destroy(collider.gameObject);
        }
    }
}
