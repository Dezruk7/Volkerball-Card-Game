using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 position;
    [Range(1,20)] public float speed = 10f;

    //New Input System
    GameInput gameInput;
    InputAction move;

    #region For the new Input System
    private void Awake()
    {
        gameInput = new GameInput();
    }
    private void OnEnable()
    {
        move = gameInput.Player1.Move;
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }
    #endregion

    void Start()
    {
        //position = transform.position;
    }

    
    void Update()
    {
        Movement();
        Boundary();
    }

    void Movement()
    {
        //"Old" Input System
        //position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //position.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //transform.position = position;

        //New Input System
        position.x += move.ReadValue<Vector2>().x * speed * Time.deltaTime;
        position.y += move.ReadValue<Vector2>().y * speed * Time.deltaTime;

        transform.position = position;
    }

    //This Clamp (as of right now) only makes sense for the Player on the left screen
    void Boundary()
    {
        position.x = Mathf.Clamp(position.x, -GameManager.gameBorderX, GameManager.gameBorderX);
        position.y = Mathf.Clamp(position.y, -GameManager.gameBorderY, GameManager.gameBorderY);
        position.x = Mathf.Clamp(position.x, -GameManager.gameBorderX, -GameManager.gameBorderMid);
    }
}
