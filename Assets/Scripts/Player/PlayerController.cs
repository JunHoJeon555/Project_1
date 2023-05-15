using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 180.0f;

    float rotateDir = 0f;
    float moveDir = 0f;

    public float maxStamina = 10;
    float currenStamina;

    bool IsRun = false;
    Rigidbody rigid;

    Animator animator;

    PlayerInputActions inputActions;

    private void Awake()
    {
        currenStamina = maxStamina;
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Attack.performed += OnAttack;
        inputActions.Player.Run.performed += OnRun;
        inputActions.Player.Run.canceled += OnRun_Cancel;
        //inputActions.Player.Run.
    }

 

    private void OnDisable()
    {
        inputActions.Player.Run.canceled -= OnRun_Cancel;
        inputActions.Player.Run.performed -= OnRun;
        inputActions.Player.Attack.performed-= OnAttack;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + Time.fixedDeltaTime * moveSpeed * moveDir * transform.forward);
        Rotate();
    }

    private void Update()
    {
        if (IsRun)
        {
            currenStamina -= Time.deltaTime;
            Debug.Log($"현재 남은 스테미나 {currenStamina}");
            if(currenStamina <= 0)
            {
                animator.SetBool("Run", false);
                Debug.LogError("스테미나 없음");
            }
        }
        
    }
    private void OnAttack(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("Attack");
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        IsRun= true;
        animator.SetBool("Run", IsRun);
     
    }
    private void OnRun_Cancel(InputAction.CallbackContext context)
    {
        IsRun = false;
        animator.SetBool("Run", IsRun);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        SetInput(input, !context.canceled);
        
    }

    private void SetInput(Vector2 input , bool move)
    {
        rotateDir = input.x;
        moveDir = input.y;
        animator.SetBool("Move", move);
    }
    void Rotate()
    {
        Quaternion rotate = Quaternion.AngleAxis(Time.fixedDeltaTime * turnSpeed * rotateDir, transform.up);
        rigid.MoveRotation(rigid.rotation * rotate);
    }

}
