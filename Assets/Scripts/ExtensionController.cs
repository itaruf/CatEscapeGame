using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionController : MonoBehaviour
{
    [SerializeField] AnimatorController _animator;
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
        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
            return;

        _animator.PlayAnimation("Destroyed");
    }
}
