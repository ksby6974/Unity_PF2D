using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� ����
    public static GameManager Instance; // GameManager.instance

    public int difficulty;  // ���̵� ����

    public float score;

    private void Update()
    {
        score += Time.deltaTime;

        //Debug.Log($"���� : {score}");

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
        // �ش� Ű���� ������ ���� �ִ´�.
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
        // ����Ƽ ���ο� "GameDifficulty" �̸����� ������ ����
        PlayerPrefs.SetInt(GameData.GameDifficulty, difficulty);
    }
}
