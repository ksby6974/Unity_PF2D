using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem JumpParticle;
    [SerializeField] ParticleSystem myParticle;

    // �÷��̾� �ӵ��� ���� ��ƼŬ�� ����
    [SerializeField] int occurAfterVelocity;

    // ��ƼŬ ���� �ֱ� ����
    [SerializeField] float dustFormationTime;

    [SerializeField] Rigidbody2D playeRb;

    float counter;  // ���� ���� �ֱ⸦ üũ�ϱ� ���� �ð� ����
    public bool isGround;  // �÷��̾��� ���� ���¸� üũ�ϱ� ���� ����

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
