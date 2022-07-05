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

    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _scratch;

    public void PrepareDirection(Vector2 v) => Direction = v.normalized;
    Coroutine MovementTracking { get; set; }

    // Animator
    [SerializeField] PlayerAnimatorController _animatorController;


    // Events
    Action<InputAction.CallbackContext> _idle;

    void Start()
    {
        // Movement
        _move.action.started += MoveInput;
        _move.action.canceled += MoveCanceled;

        // Scratch
        _scratch.action.started += Scratch;
    }

    private void OnDestroy()
    {
        _move.action.started -= MoveInput;
        _move.action.canceled -= MoveCanceled;

        _scratch.action.started -= Scratch;
    }

    void FixedUpdate()
    {
        // Update Movement
        _rb.MovePosition(_rb.position + (Direction * _speed) * Time.fixedDeltaTime);
    }

    private void Scratch(InputAction.CallbackContext obj)
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

    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) 
            return;

        PrepareDirection(Vector2.zero);

        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }
}