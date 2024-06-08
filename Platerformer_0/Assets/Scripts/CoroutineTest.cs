using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("【Start 함수】: 호출 1");
        StartCoroutine(CoTest());
        SubTest();
        Debug.Log("【Start 함수】: 호출 2");
    }

    IEnumerator CoTest()
    {
        Debug.Log("【Coroutine 함수】: 호출 1");
        yield return new WaitForSeconds(1);
        Debug.Log("【Coroutine 함수】: 호출 2");
        Debug.Log("【Coroutine 함수】: 호출 3");
    }

    // Subroutine : 메인 흐름 속에서 한 번만 호출하는 함수. 순차적으로 진행.
    // Coroutine : 메인 로직과 함께 하는 함수. 중간에 멈춰 다른 함수가 끼어들 수 있음.

    // Coroutine은 Update에서 함부로 사용하면 안 된다.Update는 1/60초로 반복되기 때문


    void SubTest()
    {
        Debug.Log("【서브 테스트 함수】: 호출 1");
        Debug.Log("【서브 테스트 함수】: 호출 2");
        Debug.Log("【서브 테스트 함수】: 호출 3");
    }
}
