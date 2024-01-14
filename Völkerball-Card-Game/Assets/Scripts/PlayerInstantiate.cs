using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInstantiate : MonoBehaviour
{
    public GameObject playerPrefab;
    PlayerController playerController;

    Vector2 startPos = new Vector2(0,0);

    private void Awake()
    {
        if (playerPrefab != null)
        {
            playerController = GameObject.Instantiate(playerPrefab, PlayerManager.instance.spawnPoints[0].transform.position, transform.rotation).GetComponent<PlayerController>();
            transform.parent = playerController.transform;
        }
    }
}
