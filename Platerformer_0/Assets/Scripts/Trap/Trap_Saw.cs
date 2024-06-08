using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;     //��Ϲ����� �̵��� ��ġ�� ������ ����
    public float speed = 10f;
    public int moveindex = 0;
    public bool OnGoing = true;
    public bool IsTrapOn = true;
    public float fStopTime = 0.1f;

    private void Start()
    {
        anim = GetComponent<Animator>();

        isWorking = true;
    }

    private void Update()
    {
        anim.SetBool("isWorking",isWorking);

        if (IsTrapOn == true)
        {
            MoveTrap();
        }
    }

    IEnumerator CoMoveTrap()
    {
        IsTrapOn = false;
        yield return new WaitForSeconds(fStopTime);
        IsTrapOn = true;
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
            moveindex += 1;
            StartCoroutine(CoMoveTrap());
            Debug.Log($"��moveindex {moveindex}��: ����");
        }

        // ���� ��ǥ �������� ����
        // ���� ��ǥ ������ ������ 0���� �ʱ�ȭ
        if (movePositions.Length <= moveindex)
        {
            moveindex = 0;
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
