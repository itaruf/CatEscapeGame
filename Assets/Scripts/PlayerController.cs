using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 1;
    public Vector2 Direction { get; private set; }

    [Header("Input Actions")]
    public InputActionReference _move;
    public InputActionReference _scratch;
    public InputActionReference _push;
    public InputActionReference _jump;

    public void PrepareDirection(Vector2 v) => Direction = v.normalized;
    Coroutine MovementTracking { get; set; }

    [Header("Icons")]
    // Icons
    public Icon _jumpIcon = null;
    public Icon _scratchIcon = null;
    public Icon _pushIcon = null;

    [Header("Animator Controller")]
    // Animator
    [SerializeField] PlayerAnimatorController _animatorController;

    // Events
    public Action _onJump;
    public Action _onPush;

    void Start()
    {
        // Movement
        _move.action.started += MoveInput;
        _move.action.canceled += MoveCanceled;

        /*_jump.action.started += JumpInput;
        _jump.action.started += MoveCanceled;*/

        // Scratch
        _scratch.action.started += ScratchInput;
        /*_scratch.action.started += MoveCanceled;*/

        // Push
        _push.action.started += PushInput;
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
        _onJump?.Invoke();
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + (Direction * _speed) * Time.fixedDeltaTime);
    }

    private void ScratchInput(InputAction.CallbackContext obj)
    {
        _animatorController.TriggerAnimation("Scratch");
    }

    private void PushInput(InputAction.CallbackContext obj)
    {
        _animatorController.TriggerAnimation("Push");
        _onPush?.Invoke();
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

        PrepareDirection(Vector2.zero);

        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPushable pushable))
        {
            /*_push.action.started += PushInput;*/
            /*_pushIcon.Activation();*/
            /*pushable.OnPush();*/
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPushable pushable))
        {
            /*_push.action.started -= PushInput;*/
            /*_pushIcon.Deactivation();*/
        }
    }
}