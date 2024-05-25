using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 충돌하기 위해서는 두 물체 중 한 물체는 Rigidbody(2D)를 컴포넌트로 소유필요
// 두 물체 전부 다 Collider를 갖고 있어야 한다.
// 플레이어와 충돌하면 충돌했을 시점에 이벤트 작동한다
public class Trap: MonoBehaviour
{
    // 충돌 이벤트를 작성할 때 모든 오브젝트를 대상으로 작성할 일은 거의 없다
    // 성능적인 면에서도 비효율적
    // 충돌 이벤트가 특정 대상만 작동하도록 태그를 붙임 (개별 오브젝트 한개씩 태그 지정)

    // Tag - 날개의 충돌 이벤트에서 사용
    // Layer - 이벤트를 작동할 때 특정 대상만 분류해주는 역할, 현 오브젝트가 여러 개의 레이어 소유 가능
    // Collider 2D

    protected bool isWorking = false;

    // Collider 2D이고 Higidbody2D여야 함.
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 태그 보유 여부 검사
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player 함정 피격 (collision 충돌)");
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        // 플레이어 태그 보유 여부 검사
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player 함정 피격 (trigger 충돌)");
        }
    }
}
