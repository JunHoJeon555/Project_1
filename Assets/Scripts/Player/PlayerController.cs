using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 180.0f;

    float rotateDir = 0f;
    float moveDir = 0f;

    Rigidbody rigid;

    Vector2 inputDir;
    PlayerInputActions inputActions;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void Update()
    {
        //transform.Translate(Time.deltaTime * moveSpeed * moveDir * transform.forward, Space.World);
        rigid.MovePosition(rigid.position*Time.fixedDeltaTime*moveDir*moveSpeed);
        Rotate();
    }


    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        SetInput(input);
    }

    private void SetInput(Vector2 input)
    {
        rotateDir = input.x;
        moveDir = input.y;
    }
    void Rotate()
    {
        Quaternion rotate = Quaternion.AngleAxis(Time.deltaTime * turnSpeed * rotateDir, transform.up);

        //이걸 실행하면 회전을 되나 그 방향으로 안감
        //Vector3 euler1 = rotate.eulerAngles;
        //transform.Rotate(euler1, Space.World);

        //리지드바디 사용하는것
        rigid.MoveRotation(rigid.rotation * rotate);
    }





}
