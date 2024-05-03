using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] InputActionProperty inputSelect; //grip
    [SerializeField] InputActionProperty inputActivate; //trigger


    private void Start()
    {
        animator = GetComponent<Animator>();

        inputSelect.action.performed += playerIsGripping;
        inputSelect.action.canceled += playerIsGripping;

        inputActivate.action.performed += playerIsSelecting;
        inputActivate.action.canceled += playerIsSelecting;
    }

    void playerIsGripping(InputAction.CallbackContext inputActionCallBack)
    {
        float inputValue = inputSelect.action.ReadValue<float>();

        animator.SetFloat("Grip", inputValue);
    }
    void playerIsSelecting(InputAction.CallbackContext inputActionCallBack)
    {

        float inputValue = inputActivate.action.ReadValue<float>();

        animator.SetFloat("Trigger", inputValue);
    }
}

