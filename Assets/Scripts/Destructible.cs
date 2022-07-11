using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IDestructible
{
    [Header("Animator Controller")]
    [SerializeField] AnimatorController _animatorController;
    [SerializeField] public string _conditionName = "";
    [SerializeField] public bool _isTrigger = true;

    [SerializeField] float _nbOfHit = 1;
    float _currentNbOfHit = 0;
    [SerializeField] float _delayBeforeDestr = 0;

    // Events
    Action _onDestroyed;

    public bool _activated = true;

    void IDestructible.OnDestroyed()
    {
        if (!_activated)
            return;

        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        _activated = false;

        float timeToStart = Time.time;

        while (Time.time - timeToStart < _delayBeforeDestr)
        {
            yield return null;
        }


        if (_isTrigger)
            _animatorController.TriggerAnimation(_conditionName);
        else
            _animatorController.PlayAnimation(_conditionName);

        _onDestroyed?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_activated)
            return;

        if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            Debug.Log("here");
            var destructible = this as IDestructible;
            PC._onPush += IncrementCounterOfHit;
            _onDestroyed += PC._scratchIcon.Deactivation;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!_activated)
            return;

        if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            Debug.Log("here");
            var destructible = this as IDestructible;
            PC._onPush -= IncrementCounterOfHit;
            _onDestroyed += PC._scratchIcon.Deactivation;
        }
    }

    bool IDestructible.IsActivated()
    {
        return _activated;
    }

    void IncrementCounterOfHit()
    {
        if (!_activated)
            return;

        _currentNbOfHit++;

        if (_currentNbOfHit == _nbOfHit)
        {
            var destructible = this as IDestructible;
            destructible.OnDestroyed();
        }
    }
}
