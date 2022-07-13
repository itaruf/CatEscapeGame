using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] AnimatorController _animator;
    [SerializeField] Fan _fan;

    public bool _activated = true;
    public Action _onActivation;
    public float _delayBeforeActivation = 2;

    void Awake()
    {
        _fan._onActivation += OnWindDetected;
    }

    void FixedUpdate()
    {
        
    }

    void OnWindDetected()
    {
        StartCoroutine(Move());
    }
    
    IEnumerator Move()
    {
        while (_fan._activated)
            yield return null;

        _animator.TriggerAnimation("RopeMove");
    }
}
