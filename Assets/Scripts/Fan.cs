using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Destructible
{
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
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

    public override void OnCollisionExit2D(Collision2D collision)
    {
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
}
