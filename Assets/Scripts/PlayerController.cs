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
    public InputActionReference _bite;
    public InputActionReference _sleep;

    public void PrepareDirection(Vector2 v) => Direction = v.normalized;
    Coroutine MovementTracking { get; set; }

    [Header("Icons")]
    // Icons
    public Icon _jumpIcon = null;
    public Icon _scratchIcon = null;
    public Icon _pushIcon = null;
    public Icon _biteIcon = null;

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

        // Bite
        _bite.action.performed += BiteInput;

        // Sleep
        _sleep.action.started += SleepInput;
    }

    private void OnDestroy()
    {
        _move.action.started -= MoveInput;
        _move.action.canceled -= MoveCanceled;

       /* _jump.action.started -= JumpInput;
        _jump.action.started -= MoveCanceled;*/

        _scratch.action.started -= ScratchInput;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + (Direction * _speed) * Time.fixedDeltaTime);
    }


    private void SleepInput(InputAction.CallbackContext obj)
    {
        Debug.Log("SLEEP");
        _animatorController.PlayAnimation("Idle", false);
        _animatorController.TriggerAnimation("Sleep");
    }

    public void JumpInput(InputAction.CallbackContext obj)
    {
        _onJump?.Invoke();
    }

    public void BiteInput(InputAction.CallbackContext obj)
    {
        if (obj.performed) 
        {
            Debug.Log("Bite");
        }

        if (obj.canceled)
        {
            Debug.Log("Bite canceled");
        }
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
                _animatorController.PlayAnimation("Walk");
                _animatorController.PlayAnimation("Idle", false);

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

        _animatorController.PlayAnimation("Walk", false);
        _animatorController.PlayAnimation("Idle", true);

        PrepareDirection(Vector2.zero);

        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDestructible destructible))
        {
            if (destructible.IsActivated())
            {
                _scratchIcon.Activation();
            }
        }

        if (collision.gameObject.TryGetComponent(out IPushable pushable))
        {
            if (pushable.IsActivated())
            {
                _scratchIcon.Activation();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDestructible destructible))
        {
            _scratchIcon.Deactivation();
        }

        if (collision.gameObject.TryGetComponent(out IPushable pushable))
        {
            _scratchIcon.Deactivation();
        }
    }
}