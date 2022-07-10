using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extension : MonoBehaviour
{
    [SerializeField] AnimatorController _animator;
    [SerializeField] Particle _Pfire;

    public bool _activated = true;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_activated)
            return;

        if (!collision.gameObject.TryGetComponent(out IPushable pushable))
            return;

        _animator.PlayAnimation("Destroyed");
        _Pfire.Activation();
        _Pfire._animatorController.PlayAnimation("FireLoop", true);
        Debug.Log("Destroyed");

        _activated = false;
    }
}
