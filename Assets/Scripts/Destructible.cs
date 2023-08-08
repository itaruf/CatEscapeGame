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
    public  Action _onDestroyed;
    public Action _onActivation;

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
            yield return null;

        if (_isTrigger)
        {
            Debug.Log(Animator.StringToHash(_conditionName));
            _animatorController.TriggerAnimation(Animator.StringToHash(_conditionName));
        }
        else
            _animatorController.PlayAnimation(_conditionName);

        _onDestroyed?.Invoke();
        _onActivation?.Invoke();
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            if (!_activated)
                PC._onScratch -= IncrementCounterOfHit;

            else
            {
                var destructible = this as IDestructible;
                PC._onScratch += IncrementCounterOfHit;
                _onDestroyed += PC._scratchIcon.Deactivation;
            }
        }*/
        if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            var destructible = this as IDestructible;

            if (!_activated)
                PC._onPush -= destructible.OnDestroyed;

            else
            {
                PC._onPush += destructible.OnDestroyed;
                _onDestroyed += PC._scratchIcon.Deactivation;

            }
        }
    }

    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        /* if (collision.gameObject.TryGetComponent(out PlayerController PC))
         {
             if (!_activated)
                 PC._onScratch -= IncrementCounterOfHit;

             else
             {
                 var destructible = this as IDestructible;
                 PC._onScratch -= IncrementCounterOfHit;
                 _onDestroyed += PC._scratchIcon.Deactivation;
             }
         }*/

        if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            if (_activated)
            {
                var destructible = this as IDestructible;
                PC._onPush -= destructible.OnDestroyed;
                _onDestroyed += PC._scratchIcon.Deactivation;
            }
        }
    }

    bool IDestructible.IsActivated()
    {
        return _activated;
    }

    public void IncrementCounterOfHit()
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
