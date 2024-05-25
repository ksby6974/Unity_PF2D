using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;     //��Ϲ����� �̵��� ��ġ�� ������ ����
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
        // �������� ��ǻ�� ȯ�濡 ���� �ٸ��� ������
        // Time.deltaTime�� �����ش�
        // ���� ������� 0.0016�� ��
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveindex].position, speed * Time.deltaTime);

        // ������ ��ǥ�� �������� �����ߴ°�
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

            // ���� ��ǥ �������� ����
            // ���� ��ǥ ������ ������ 0���� �ʱ�ȭ
        }
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾� �±� ���� ���� �˻�
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player ���� �ǰ� (collision �浹)");
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        // �÷��̾� �±� ���� ���� �˻�
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player ���� �ǰ� (trigger �浹)");

            //�÷��̾� �ı�
            Destroy(collider.gameObject);
        }
    }
}
