using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extension : MonoBehaviour
{
    [SerializeField] AnimatorController _animator;
    [SerializeField] Particle _Pfire;

    public bool _activated = true;
    public Action _onActivation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_activated)
            return;

        if (!collision.gameObject.TryGetComponent(out IPushable pushable))
            return;

        _onActivation?.Invoke();
        _activated = false;

        if (!_animator)
            return;

        _animator.PlayAnimation("Destroyed");

        if (!_Pfire)
            return;

        _Pfire.Activation();
        _Pfire._animatorController.PlayAnimation("FireLoop", true);
    }
}
