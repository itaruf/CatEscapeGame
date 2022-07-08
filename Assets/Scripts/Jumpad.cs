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
            return;

        PC._jump.action.started += PC.JumpInput;
        PC._jump.action.started += PC.MoveCanceled;
        PC._jump.action.started += JumpInput;

        target = collision.gameObject;

        Debug.Log("test");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
            return;

        StopCoroutine(JumpAnim(target, _jumpEnter.gameObject));
        StopCoroutine(JumpAnim(target, _jumpExit.gameObject));

        PC._jump.action.started -= PC.JumpInput;
        PC._jump.action.started -= PC.MoveCanceled;
        PC._jump.action.started -= JumpInput;

    }
    public void JumpInput(InputAction.CallbackContext obj)
    {
        if (!_activated)
            StartCoroutine(JumpAnim(target, _jumpEnter.gameObject));
        else
            StartCoroutine(JumpAnim(target, _jumpExit.gameObject));
    }

    IEnumerator JumpAnim(GameObject start, GameObject end)
    {
        float timeToStart = Time.time;
        var s = start.transform.position;
        var e = end.transform.position;

        while (Vector3.Distance(start.transform.position, e) > 0.05f)
        {
            start.transform.position = Vector3.Slerp(s, e /*+ new Vector3(0, _jumpCurve.Evaluate(Time.time - timeToStart) * _speed, 0)*/, (Time.time - timeToStart) * _speed); 

            yield return null;

        }
        _activated = !_activated;
        Debug.Log(_activated);
    }
}