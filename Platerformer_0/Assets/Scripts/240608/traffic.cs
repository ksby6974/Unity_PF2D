using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class traffic : MonoBehaviour
{
    private float fTimer;
    private float fCount;
    private float fLimit_Time = 3f;
    public const float fStopTime = 3f;
    public int iLight = 0;
    public int iLimit_Light = 3;
    public bool iIsLightOn = true;
    SpriteRenderer spriterender;
    public GameObject[] Traps;
    public GameObject obj_traffic;
    public GameObject obj_player;

    // Start is called before the first frame update
    private void Start()
    {
        fCount = Time.time;
        spriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Count();

        if (iIsLightOn == true)
        {
            ColorChange();
        }
    }

    IEnumerator CoSet()
    {
        Debug.Log($"Wait:{fStopTime}");

        iIsLightOn = false;
        yield return new WaitForSeconds(fStopTime);
        iIsLightOn = true;
    }

    private void ColorChange()
    {
        string sTemp = "Trap";

        switch (iLight)
        {
            // wind
            case 0:
                spriterender.color = Color.green;
                sTemp = "! ! Wind ! !";
                break;

            // water
            case 1:
                spriterender.color = Color.blue;
                sTemp = "! ! Water ! !";
                break;

            // gravity
            case 2:
                spriterender.color = Color.black;
                sTemp = "! ! Gravity ! !";
                break;

            // yellow
            case 3:
                spriterender.color = Color.yellow;
                sTemp = "! ! Don't Move ! !";
                break;

            default:
                break;
        }

        Disable_Traps();
        Active_Traps(iLight, sTemp);
        StartCoroutine(CoSet());

        if (iLight == iLimit_Light)
        {
            iLight = 0;
        }
        else
        {
            iLight += 1;
        }
    }

    private void Disable_Traps()
    {
        for (int i = 0; i < Traps.Length; i++)
        {
            Traps[i].SetActive(false);
        }
    }

    private void Active_Traps(int i, string s)
    {
        Traps[i].SetActive(true);
        //Debug.Log($"Traps Active:{i}");

        if (obj_traffic.GetComponent<TMP_Text>() != null)
        {
            TMP_Text TrapText = obj_traffic.GetComponent<TMP_Text>();
            TrapText.text = s;
        }
    }

    private void Count()
    {
        if (iIsLightOn == false)
            fTimer += Time.deltaTime;

        Debug.Log($"Count : {fTimer}");

        if (fTimer >= fLimit_Time)
        {
            //fTimer = 0;
            //iIsLightOn = true;
        }
    }
}
