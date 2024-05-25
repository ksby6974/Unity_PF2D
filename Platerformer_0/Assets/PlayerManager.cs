using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnTransform;    // 체크 포인트, 세이브 포인트 시작 위치 변경해주는 기능

    [SerializeField] private PlayerCam playercam;                //PlayerCam 클래스에 접근. RespawnPlayer에서 접근할 수 있게 코드 작성
    private Player_MainMove playerController;   //Player_MainMove에서 빠진 컴포넌트들을 추가해줘야 합니다.
 
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log($"Player 생성 확인");
            RespawnPlayer();
        }

        // 만약 player 변수가 null이면 Respawn을 해라
        if (player != null)
        {
           // RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        player = Instantiate(playerPrefab, spawnTransform.position, Quaternion.identity);
        playerController = player.GetComponent<Player_MainMove>(); // 다른 코드에 접근하는 방법

        playercam.playerTransform = player.transform;
        playercam.setOffset();
    }
}
