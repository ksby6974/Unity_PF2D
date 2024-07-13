using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI currentScoreText;

    public void Update()
    {
        levelText.text = GameManager.Instance.ReturnCurrentDifficulty();
        currentScoreText.text = "������ : " + GameManager.Instance.score.ToString("#.##") + "��";
        bestScoreText.text = "�ְ��� : " + PlayerPrefs.GetFloat(GameData.BestScore).ToString("#.##") + "��";
    }

    public void ResetRecord()
    {
       //bestScoreText.text = "�ְ���" + PlayerPrefs.GetFloat(GameData.BestScore).ToString("#.##") + "��";
    }

    public void StartNewGame()
    {
        // 2��° ��ġ�� �ִ� ���� �ε�
        SceneManager.LoadScene(1);
    }

    // ��ư�� �����ų �Լ� �̸�
    public void SwitchMenuTo(GameObject uiMenu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // ���� �ڽĵ� ��Ȱ��ȭ
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // ��� ������Ʈ Ȱ��ȭ
        uiMenu.SetActive(true);
    }

    public void SetGameLevel(int level)
    {
        GameManager.Instance.difficulty = level;
        GameManager.Instance.SaveGameInfo();
    }
}
