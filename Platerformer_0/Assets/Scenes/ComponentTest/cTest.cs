using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject TestObject;
    // NullRefence 에러. 변수에 데이터가 없어서 발생하는 에러.
    // 해결하기 위해서는 데이터 초기화, 생성 초기화 이벤트 함수에 데이터 변수 할당하는 작업 필요

    // Awake -> OnEnable -> Start 순서로 실행됨
    private void Awake()
    {
        Debug.Log("Awake 실행");
        TestObject = new GameObject();
    }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start 실행");
        TestObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 실행");

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 실행");
    }

    private void Update()
    {
        Debug.Log("Update 실행");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate 실행");
    }
}
