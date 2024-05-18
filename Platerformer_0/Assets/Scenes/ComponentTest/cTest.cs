using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject TestObject;
    // NullRefence ����. ������ �����Ͱ� ��� �߻��ϴ� ����.
    // �ذ��ϱ� ���ؼ��� ������ �ʱ�ȭ, ���� �ʱ�ȭ �̺�Ʈ �Լ��� ������ ���� �Ҵ��ϴ� �۾� �ʿ�

    // Awake -> OnEnable -> Start ������ �����
    private void Awake()
    {
        Debug.Log("Awake ����");
        TestObject = new GameObject();
    }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start ����");
        TestObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable ����");

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate ����");
    }

    private void Update()
    {
        Debug.Log("Update ����");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate ����");
    }
}
