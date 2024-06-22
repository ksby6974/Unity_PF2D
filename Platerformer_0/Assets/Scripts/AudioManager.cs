using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] sfx;
    public AudioSource[] bgm;
    public int iIndex;
    public int iCurrentIndex;
    public float fCount;
    public float fWait;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        iIndex = 0;
        iCurrentIndex = 0;
        fCount = 0;
        fWait = 0;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            PlayRandomBGM();
        }

        if (fWait == 0)
        {
            //PlayRandomBGM();
            fWait = 1;
        }
        else
        {
            fCount += Time.deltaTime;

            if (fCount > 0)
            {
                Debug.Log($"Count : {fCount} ─ Index:{iCurrentIndex}");
            }
        }
    }


    public void PlayBGM(int bgmIndex)
    {
        bgm[bgmIndex].Play();

        //bgm[iIndex].time
    }

    private void StopBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    public void PlayRandomBGM()
    {
        // 이전 실행된 bgm 정지
        StopBGM();

        int randomIndex = Random.Range(0,bgm.Length);
        PlayBGM(randomIndex);
    }

    public void PlaySFX_SET()
    {
        int index = 0;
        sfx[index].pitch = Random.Range(0.8f, 1.2f);
        sfx[index].Play();
    }

    public void PlaySFX(int Index)
    {
        sfx[Index].Play();
        sfx[Index].volume = 0.5f;

        //bgm[iIndex].time
    }

    public void PlayRandomSFX()
    {
        int randomIndex = Random.Range(0, sfx.Length);
        PlaySFX(randomIndex);
    }
}
