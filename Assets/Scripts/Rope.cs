using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] AnimatorController _animator;
    [SerializeField] Fan _fan;
    [SerializeField] LightBulb _lightBulb;

    public bool _activated = true;
    public Action _onActivation;
    public float _delayBeforeActivation = 2;

    [SerializeField] BoxCollider2D _collider;
    [SerializeField] Vector3 _offset = new Vector3(2, 0, 0);
    [SerializeField] float _speed = 1;

    Vector3 startLoc = new Vector3();

    void Awake()
    {
        _fan._onActivation += OnWindDetected;
        startLoc = transform.position;
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

        while (_lightBulb._activated)
            yield return null;

        _animator.TriggerAnimation("RopeMove");
        _onActivation?.Invoke();

        var start = transform.position;
        var end = startLoc + _offset;

        StartCoroutine(M(start, end));
    }

    IEnumerator M(Vector3 start, Vector3 end)
    {
        float timeToStart = Time.time;

        while (Vector3.Distance(transform.position, end) > Mathf.Epsilon)
        {

            transform.position = Vector3.Lerp(start, end, (Time.time - timeToStart) * _speed);
            yield return null;
        }

        _offset = new Vector3(-_offset.x, _offset.y, _offset.z);
        StartCoroutine(Move());
    }
}
