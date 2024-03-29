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
    [SerializeField] public PlayerAnimatorController _animatorController;

    // Events
    public Action _onJump;
    public Action _onPush;
    public Action _onScratch;
    public Action _onBite;
    public Action _onSleep;

    delegate void Delegate();
    Delegate _onS;

    // bool
    public bool _isJumping = false;

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

        // Subscriptions
        /*_onSleep += () => { Params("Idle", "Walk"); };*/
    }

    private void OnDestroy()
    {
        _move.action.started -= MoveInput;
        _move.action.canceled -= MoveCanceled;

        /*_jump.action.started -= JumpInput;
        _jump.action.started -= MoveCanceled;*/

        _scratch.action.started -= ScratchInput;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + (Direction * _speed) * Time.fixedDeltaTime);
    }

    public void Params(params string[] list)
    {
       /* Debug.Log("HERE");*/
        foreach (string name in list)
        {
            Debug.Log(name);
            _animatorController.TriggerAnimation(name, false);
        }
    }

    private void SleepInput(InputAction.CallbackContext obj)
    {
        if (_isJumping)
            return;

        _onSleep?.Invoke();
        _animatorController.TriggerAnimation("Sleep");
    }

    public void JumpInput(InputAction.CallbackContext obj)
    {
        if (_isJumping)
            return;

        _animatorController.TriggerAnimation("Jump");
        _onJump?.Invoke();
    }

    public void BiteInput(InputAction.CallbackContext obj)
    {
        if (_isJumping)
            return;

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
        if (_isJumping)
            return;

        _animatorController.TriggerAnimation("Scratch");
        _onScratch?.Invoke();
    }

    private void PushInput(InputAction.CallbackContext obj)
    {
        if (_isJumping)
            return;

        _animatorController.TriggerAnimation("Push");
        _onPush?.Invoke();
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (_isJumping)
            return;

        if (MovementTracking != null) 
            return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                /*while (_isJumping)
                    yield return null;*/

                _animatorController.TriggerAnimation("Walk");

                PrepareDirection(obj.ReadValue<Vector2>());
                _animatorController.FlipSprite(obj.ReadValue<Vector2>());

                yield return null;
            }
        }
    }

    public void MoveCanceled(InputAction.CallbackContext obj)
    {
        if (_isJumping)
            return;

        if (MovementTracking == null) 
            return;

        StopCoroutine(MovementTracking);
        MovementTracking = null;
        PrepareDirection(Vector2.zero);

        _animatorController.TriggerAnimation("Walk", false);
        _animatorController.TriggerAnimation("Idle");
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

    public void SetIsJumping(bool value)
    {
        _isJumping = value;
    }
}