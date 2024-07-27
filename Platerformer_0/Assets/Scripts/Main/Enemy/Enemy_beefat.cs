using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_beefat : Enemy
{
    public GameObject obj;
    public float fPower;

    void Start()
    {
        fPower = 0.0001f;
        obj.GetInstanceID();
    }

    void Update()
    {
        fPower += 0.00001f;
        this.transform.position += new Vector3(0, -fPower, 0);

        //rgbody2D.velocity = new Vector2(rgbody2D.velocity.x, fPower);
    }
}
