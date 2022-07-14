using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpPoint : MonoBehaviour
{
    private GameObject _startLoc;
    [SerializeField] GameObject _landingLoc;

    [SerializeField] float _speed;

    public bool _activated = true;

    //Events
    public Action _onAnimStart;
    public Action _onAnimEnd;

    Coroutine _jumpAnimTracking;

    void Awake()
    {
        if (!_landingLoc)
            _landingLoc = GetComponentInChildren<GameObject>(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_activated)
            return;

        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
            return;

        PC._jump.action.started += PC.JumpInput;
        PC._jump.action.started += PC.MoveCanceled;
        PC._onJump += JumpInput;

        _startLoc = collision.gameObject;

        PC._jumpIcon.Activation();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_activated)
            return;

        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
            return;

        PC._jump.action.started -= PC.JumpInput;
        PC._jump.action.started -= PC.MoveCanceled;
        PC._onJump -= JumpInput;

        PC._jumpIcon.Deactivation();
    }

    public void JumpInput()
    {
        if (_jumpAnimTracking != null)
            return;

        _jumpAnimTracking = StartCoroutine(JumpAnim(_startLoc, _landingLoc));
    }

    IEnumerator JumpAnim(GameObject start, GameObject end)
    {
        if (start.TryGetComponent(out PlayerController PC))
            PC._isJumping = true;

        _onAnimStart?.Invoke();

        float timeToStart = Time.time;
        var s = start.transform.position;
        var e = end.transform.position;

        while (Vector3.Distance(start.transform.position, e) > Mathf.Epsilon)
        {
            start.transform.position = Vector3.Lerp(s, e, (Time.time - timeToStart) * _speed);
            yield return null;
        }

        if (PC)
            PC._isJumping = false;

        _jumpAnimTracking = null;
        _onAnimEnd?.Invoke();
    }
}