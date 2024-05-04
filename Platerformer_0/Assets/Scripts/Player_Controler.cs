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
    public float moveSpeed = 16f;    // ĳ���� �̵� �ӵ�
    public float JumpForce = 12f;   // ĳ���� ����
    private float moveInput;        // ĳ������ ���� �� ��ǲ ������ ����

    public Transform startTransform;    // ĳ���Ͱ� ������ ��ġ ����
    public Rigidbody2D rigidbody2D;     // ����(��ü) ����� �����ϴ� ������Ʈ 

    [Header("Jump")]
    public bool isGrounded;      // ĳ���Ͱ� ������ �� �ִ� ����
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log($"Start Ȯ���߽��ϴ�.");
        // ���� �� ���� <= ���ο� x,y �����ϴ� ������ Ÿ��
        //transform.position = new Vector2(transform.position.x, 10);
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1�����Ӹ��� �ݺ������� ȣ��
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);

        // �÷��̾��� �Է°� �ޱ�
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);

        //�����̽� Ű�� �Է� �� ����
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // ���� : Y position _ rigidbody Y velocity�� ���� �Ŀ���ŭ
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}
