using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI currentPlayerHp;
    public Player_MainMove player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScoreText.text = $"Score : {ShowScore()}";

        //currentScoreText.text = "Score : " + GameManager.Instance.score.ToString("#.##");
        levelText.text = "Level : " + GameManager.Instance.ReturnCurrentDifficulty();
        currentPlayerHp.text = $"HP : {player.currentHp}";
    }

    private string ShowScore()
    {
        string text;
        //float f = GameManager.Instance.score();
        text = $"{GameManager.Instance.score}";

        return text;
    }
}
