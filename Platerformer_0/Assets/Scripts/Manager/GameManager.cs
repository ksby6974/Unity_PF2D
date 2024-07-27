using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴
    public static GameManager Instance; // GameManager.instance

    public int difficulty;  // 난이도 설정

    public float score;

    private void Update()
    {
        score += Time.deltaTime;

        //Debug.Log($"점수 : {score}");

        if (score > PlayerPrefs.GetFloat(GameData.BestScore))
        {
            PlayerPrefs.SetFloat(GameData.BestScore, score);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetFloat(GameData.BestScore, score);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        // 해당 키값이 존재할 때만 넣는다.
        if (PlayerPrefs.HasKey(GameData.GameDifficulty))
        {
            difficulty = PlayerPrefs.GetInt(GameData.GameDifficulty);
        }
    }

    public string ReturnCurrentDifficulty()
    {
        string name = null;

        switch(difficulty)
        {
            case 0:
                name = "Easy";
                break;

            case 1:
                name = "Normal";
                break;

            case 2:
                name = "Hard";

                break;
            default:
                name = "Empty";
                break;
        }

        return $"{name}";
    }

    public void SaveGameInfo()
    {
        // 유니티 내부에 "GameDifficulty" 이름으로 변수를 저장
        PlayerPrefs.SetInt(GameData.GameDifficulty, difficulty);
    }
}
