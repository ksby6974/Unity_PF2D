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
        currentScoreText.text = "현재기록 : " + GameManager.Instance.score.ToString("#.##") + "초";
        bestScoreText.text = "최고기록 : " + PlayerPrefs.GetFloat(GameData.BestScore).ToString("#.##") + "초";
    }

    public void ResetRecord()
    {
       //bestScoreText.text = "최고기록" + PlayerPrefs.GetFloat(GameData.BestScore).ToString("#.##") + "초";
    }

    public void StartNewGame()
    {
        // 2번째 위치에 있는 씬을 로드
        SceneManager.LoadScene(1);
    }

    // 버튼에 연결시킬 함수 이름
    public void SwitchMenuTo(GameObject uiMenu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // 하위 자식들 비활성화
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // 대상 오브젝트 활성화
        uiMenu.SetActive(true);
    }

    public void SetGameLevel(int level)
    {
        GameManager.Instance.difficulty = level;
        GameManager.Instance.SaveGameInfo();
    }
}
