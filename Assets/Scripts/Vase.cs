using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour, IPushable
{
    enum Direction { UP, BW, R, L};

    [Header("Movemment")]
    [SerializeField] Direction _direction;
    [SerializeField] float _speed =  2;
    [SerializeField] float _pushDistance = 1;


    [Header("Animator Controller")]
    [SerializeField] AnimatorController _animatorController;

    bool _activated = true;
    public Action _onDeactivation;

    void Awake()
    {
        if (!_animatorController)
            TryGetComponent<AnimatorController>(out _animatorController);

       /* var v = this as IPushable;
        v.OnPush();*/
    }


    void IPushable.OnPush()
    {
        if (!_activated)
            return;

        switch (_direction)
        {
            case Direction.UP:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(0, _pushDistance, 0)));
                break;
            case Direction.BW:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(0, -_pushDistance, 0)));
                break;
            case Direction.R:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(_pushDistance, 0, 0)));
                break;
            case Direction.L:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(-_pushDistance, 0, 0)));
                break;
        }
    }

    IEnumerator PushAnim(Vector3 start, Vector3 end)
    {
        float timeToStart = Time.time;
        var s = start;
        var e = end;

        _onDeactivation?.Invoke();
        _activated = false;

        while (Vector3.Distance(transform.position, e) > Mathf.Epsilon)
        {
            transform.position = Vector3.Lerp(s, e, (Time.time - timeToStart) * _speed);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_activated)
            return;

        if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            PC._pushIcon.Activation();

            var v = this as IPushable;
            PC._onPush += v.OnPush;

            _onDeactivation += PC._pushIcon.Deactivation;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!_activated)
            return;

        if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            PC._pushIcon.Deactivation();

            var v = this as IPushable;
            PC._onPush -= v.OnPush;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Extension extension))
        {
            _animatorController.PlayAnimation("VaseDestroyed");
        }
    }
}
