using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[SelectionBase]
[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1, 20)] private float speed = 10f;

    //For the Player Input Component
    private Vector2 movementInput = Vector2.zero;
    private CharacterController controller;

    //private Vector2 position;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        //position = transform.position;
    }

    //For the Player Input Component
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
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

        ////New Input System
        //position.x += move.ReadValue<Vector2>().x * speed * Time.deltaTime;
        //position.y += move.ReadValue<Vector2>().y * speed * Time.deltaTime;
        //transform.position = position;


        //For the Player Input Component
        Vector2 move = new Vector2(movementInput.x, movementInput.y);
        controller.Move(move * speed * Time.deltaTime);

        //if (move != Vector2.zero)
        //{
        //    gameObject.transform.position = move;
        //}

        
    }

    //This Clamp (as of right now) only makes sense for the Player on the left half
    void Boundary()
    {
        //position.x = Mathf.Clamp(position.x, -GameManager.gameBorderX, GameManager.gameBorderX);
        //position.y = Mathf.Clamp(position.y, -GameManager.gameBorderY, GameManager.gameBorderY);
        //position.x = Mathf.Clamp(position.x, -GameManager.gameBorderX, -GameManager.gameBorderMid);
    }
}
