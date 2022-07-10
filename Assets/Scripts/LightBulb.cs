using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    [SerializeField] Extension _extension;

    [SerializeField] AnimatorController _animator;
    [SerializeField] Particle _Pfire;

    public bool _activated = true;
    public Action _onActivation;

    void Awake()
    {
        if (!_extension)
            return;

        _extension._onActivation += Burn;
    }

    private void OnDestroy()
    {
        if (!_extension)
            return;

        _extension._onActivation -= Burn;
    }

    void Burn()
    {
        if (!_activated)
            return;

        _activated = false;
        _onActivation?.Invoke();

        if (!_animator)
            return;

        _animator.TriggerAnimation("LightOff");

        if (!_Pfire)
            return;

        _Pfire.Activation();
        _Pfire._animatorController.PlayAnimation("FireLoop", true);
    }
}
