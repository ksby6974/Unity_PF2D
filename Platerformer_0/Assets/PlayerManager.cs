using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnTransform;    // üũ ����Ʈ, ���̺� ����Ʈ ���� ��ġ �������ִ� ���

    [SerializeField] private PlayerCam playercam;                //PlayerCam Ŭ������ ����. RespawnPlayer���� ������ �� �ְ� �ڵ� �ۼ�
    private Player_MainMove playerController;   //Player_MainMove���� ���� ������Ʈ���� �߰������ �մϴ�.
 
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
            Debug.Log($"Player ���� Ȯ��");
            RespawnPlayer();
        }

        // ���� player ������ null�̸� Respawn�� �ض�
        if (player != null)
        {
           // RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        player = Instantiate(playerPrefab, spawnTransform.position, Quaternion.identity);
        playerController = player.GetComponent<Player_MainMove>(); // �ٸ� �ڵ忡 �����ϴ� ���

        playercam.playerTransform = player.transform;
        playercam.setOffset();
    }
}
