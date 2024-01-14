using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    
    public List<PlayerInput> playerList = new List<PlayerInput>();

    [SerializeField] InputAction joinedAction;
    //[SerializeField] InputAction leftAction;

    //Instances
    public static PlayerManager instance = null;

    //Events
    public event System.Action<PlayerInput> playerJoined;
    //public event System.Action<PlayerInput> playerLeft;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        joinedAction.Enable();
        joinedAction.performed += context => JoinedAction(context);

        //leftAction.Enable();
        //leftAction.performed += context => LeftAction(context);
    }
    private void Start()
    {
        PlayerInputManager.instance.JoinPlayer(0, -1, null);
    }

    void OnPlayerJoined(PlayerInput input)
    {
        playerList.Add(input);

        if(playerJoined != null)
        {
            playerJoined.Invoke(input);
        }
        Debug.Log("Test: Player joined");
    }
    //void OnPlayerLeft(PlayerInput input)
    //{
    //    Debug.Log("Test: Player left");
    //}

    void JoinedAction(InputAction.CallbackContext context)
    {
        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context);
    }
    //void LeftAction(InputAction.CallbackContext context)
    //{

    //}
}
