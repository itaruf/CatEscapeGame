using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jumpad : MonoBehaviour
{
    [SerializeField] Transform _jumpEnter;
    [SerializeField] Transform _jumpExit;

    [SerializeField] AnimationCurve _jumpCurve;
    [SerializeField] float _speed = 2;
    GameObject target = null;

    bool _activated = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (!_jumpEnter)
            _jumpEnter = GetComponentInChildren<Transform>(true);

        if (!_jumpExit)
            _jumpExit = GetComponentInChildren<Transform>(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            PC._jump.action.started -= PC.JumpInput;
            PC._jump.action.started -= PC.MoveCanceled;
            PC._jump.action.started -= JumpInput;

            StopCoroutine(JumpAnim(target));
            return;
        }

        PC._jump.action.started += PC.JumpInput;
        PC._jump.action.started += PC.MoveCanceled;
        PC._jump.action.started += JumpInput;

        target = collision.gameObject;
    }

    public void JumpInput(InputAction.CallbackContext obj)
    {
        StartCoroutine(JumpAnim(target));
    }

    IEnumerator JumpAnim(GameObject target)
    {
        float timeToStart = Time.time;
        var start = target.transform.position;

        while (Vector3.Distance(transform.position, target.transform.position) > 0.05f)
        {
            target.transform.position = Vector3.Lerp(start, transform.position + new Vector3(0, _jumpCurve.Evaluate(Time.time - timeToStart) * _speed, 0), (Time.time - timeToStart) * _speed); 

            yield return null;

        }
    }
}