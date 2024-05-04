using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Floor_Move1 : MonoBehaviour
{
    bool bDirection = true;
    int iTemp = 0;
    float fbarSpeed = 0.1f;
    float fLimit = 30f;

    //
    [Header("Info")]
    public Rigidbody2D rigidbody2D;
    public Transform startTransform;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newpos = new Vector2(0, 0);

        if(Vector2.Distance(transform.position, newpos) <= 0)
        {

        }
    
        if(iTemp > fLimit)
        {
            ++iTemp;
            rigidbody2D.velocity =
    new Vector2(rigidbody2D.velocity.x + fbarSpeed, rigidbody2D.velocity.y);
        }

        else if(iTemp > -fLimit)
        {

        }
        Debug.Log($"iTemp : {iTemp}");
    }
}
