using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem JumpParticle;
    [SerializeField] ParticleSystem myParticle;

    // 플레이어 속도에 따라 파티클을 생성
    [SerializeField] int occurAfterVelocity;

    // 파티클 생성 주기 결정
    [SerializeField] float dustFormationTime;

    [SerializeField] Rigidbody2D playeRb;

    float counter;  // 먼지 생성 주기를 체크하기 위한 시간 변수
    public bool isGround;  // 플레이어의 점프 상태를 체크하기 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        dustFormationTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
       // Debug.Log($"{counter}");

        CheckAfterVelocity();
    }

    private void CheckAfterVelocity()
    {
        if (isGround && Mathf.Abs(playeRb.velocity.x) > occurAfterVelocity)
        {
            CheckDustFormationTime();
        }
    }

    private void CheckDustFormationTime()
    {
        if (counter > dustFormationTime)
        {
            movementParticle.Play();
            counter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            JumpParticle.Play();
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    public void PlayParticle()
    {
        myParticle.Play();
    }
}
