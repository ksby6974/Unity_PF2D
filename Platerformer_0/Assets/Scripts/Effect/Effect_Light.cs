using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Light : MonoBehaviour
{
    public GameObject Center;
    private Vector3 CenterPos;
    private Vector3 Offset;
    private Vector3 ToPos;

    static public float fLimit = 6;
    public float UpSpeed = 0.01f;
    public float fRadius;
    public float fSpeed;
    public float fDelay;
    public float fLerp;

    // Update is called once per frame
    void Update()
    {


        CenterPos = Center.transform.position;

        Offset = new Vector3(
            Mathf.Cos(Time.timeSinceLevelLoad * fSpeed + fDelay * (float)Mathf.PI * 2),
            Mathf.Sin(Time.timeSinceLevelLoad * fSpeed + fDelay * (float)Mathf.PI * 2)
        );

        if (fLimit > transform.position.x)
            transform.position = new Vector2(transform.position.x + UpSpeed, transform.position.y);


        Debug.Log($"{transform.position}");
    }
}




//ToPos = CenterPos + Offset;
//transform.position = Vector3.Lerp(transform.position, ToPos, fLerp);
