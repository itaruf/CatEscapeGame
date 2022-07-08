using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 1;
    public Vector2 Direction { get; private set; }

    public InputActionReference _move;
    public InputActionReference _scratch;
    public InputActionReference _jump;

    public void PrepareDirection(Vector2 v) => Direction = v.normalized;
    Coroutine MovementTracking { get; set; }
    // Animator
    [SerializeField] PlayerAnimatorController _animatorController;


    // Events
    Action<InputAction.CallbackContext> _onJump;

    void Start()
    {
        // Movement
        _move.action.started += MoveInput;
        _move.action.canceled += MoveCanceled;

        /*_jump.action.started += JumpInput;
        _jump.action.started += MoveCanceled;*/

        // ScratchInput
        _scratch.action.started += ScratchInput;
        /*_scratch.action.started += MoveCanceled;*/
    }

    private void OnDestroy()
    {
        _move.action.started -= MoveInput;
        _move.action.canceled -= MoveCanceled;

       /* _jump.action.started -= JumpInput;
        _jump.action.started -= MoveCanceled;*/

        _scratch.action.started -= ScratchInput;
    }

    public void JumpInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + (Direction * _speed) * Time.fixedDeltaTime);
    }

    private void ScratchInput(InputAction.CallbackContext obj)
    {
        _animatorController.TriggerAnimation("Scratch");
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null) 
            return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                PrepareDirection(obj.ReadValue<Vector2>());
                _animatorController.FlipSprite(obj.ReadValue<Vector2>());

                yield return null;
            }
        }
    }

    public void MoveCanceled(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) 
            return;

        Debug.Log("CANCELED");
        PrepareDirection(Vector2.zero);

        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }
}