using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // 벡터의 연산으로 구현
    Vector3 offset;             // 카메라와 플레이어의 위치 차이
    public Transform playerTransform;   // 플레이어의 위치(움직일 때마다 변경)
    public float fixedYPosition;        // 카메라의 Y 위치값을 고정
    [Range(0f, 1f)]                     // 아래 변수의 크기를 한정하는 문법
    public float smoothValue = 0.015f;  // 카메라의 선형 보간(부드러운 움직임)을 위해 두 위치 사이에 어느 정도 Percent 이동을 할 것인가

    // Start is called before the first frame update
    void Start()
    {
        //(GameObject) = 가져와서 Prefab생성 PlayerTransform 위치가 필요
        //playerTransform = transform;

        //transform = camera, 벡터의 합, 빼기 -> A - B : B에서 출발해서 A까지 이동하는 화살표
        offset = transform.position - playerTransform.position;

        fixedYPosition = transform.position.y;
    }

    public void setOffset()
    {
        offset = transform.position - playerTransform.position;
    }

    // Lerp. Linear Interpolation 선형 보간
    // 양 끝점을 때, 두 점 사이의 임의의 위치를 쉽게 파악하기 위한 수학적 개념
    // 두 점(Point)-(Vector3) 카메라의 현재 위치. 이동하고 싶은 위치, 카메라 → Point → 목표 순서

    // 플레이어의 움직임 Update 실행된 후에 카메라가 쫓아서 움직이기 위해서
    // Vector3.Lerp함수 구현이 되어있습니다


    // Update is called once per frame
    void LateUpdate()
    {
        // 플레이어가 움직임
        //offset = transform.position - playerTransform.position;

        // 벡터의 한 연산으로 카메라의 위치를 구한다.
        // 카메라의 Y높이를 고정시킨다.
        Vector3 targetPosition = playerTransform.position + offset;
        targetPosition.y = fixedYPosition;

        // 벡터의 합
        // 실제로 플레이어의 x방향으로만 따라다니고, Y는 고정값으로
        Vector3 smoothPosition = Vector3.Lerp(new Vector3(transform.position.x, fixedYPosition, transform.position.z), targetPosition, smoothValue);
        transform.position = smoothPosition;
    }
}
