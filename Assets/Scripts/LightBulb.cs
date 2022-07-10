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
    public float _delayBeforeActivation = 2;

    void Awake()
    {
        if (!_extension)
            return;

        _extension._onActivation += OnBurn;
    }

    private void OnDestroy()
    {
        if (!_extension)
            return;

        _extension._onActivation -= OnBurn;
    }

    private void OnBurn()
    {
        StartCoroutine(Burn());
    }

    IEnumerator Burn()
    {
        if (!_activated)
            yield return null;

        float timeToStart = Time.time;

        while (Time.time - timeToStart < _delayBeforeActivation)
        {
            yield return null;
        }

        _activated = false;
        _onActivation?.Invoke();

        if (!_animator)
            yield return null;

        _animator.TriggerAnimation("LightOff");

        if (!_Pfire)
            yield return null;

        _Pfire.Activation();
        _Pfire._animatorController.PlayAnimation("FireLoop", true);
    }
}
