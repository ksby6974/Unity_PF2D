using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public GameObject[] patternList;

    // �ε���
    [Header("Current Pattern Info")]
    public int patternIndex = 0;
    public GameObject currentPattern;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject pattern in patternList)
        {
            pattern.gameObject.SetActive(false);
        }

        ChangePattern();
    }

    // Update is called once per frame
    void Update()
    {
        // GameController ���� ������ ���� ���ΰ� �˻�

        // ChangePattern

        if (currentPattern.activeSelf == false)
        {
            ChangePattern();
        }
    }

    public void ChangePattern()
    {
        currentPattern = patternList[patternIndex];
        currentPattern.SetActive(true);

        patternIndex += 1;

        if (patternIndex >= patternList.LongLength)
        {
            patternIndex = 0;
        }
    }
}
