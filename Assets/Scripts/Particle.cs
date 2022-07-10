using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [Header("Animator Controller")]
    // Animator
    public AnimatorController _animatorController;

    [Header("Sprite Renderer")]
    [SerializeField] SpriteRenderer _spriteRenderer;
    public bool _showParticle = false;

    void Awake()
    {
        if (!TryGetComponent(out _spriteRenderer))
            return;

        _spriteRenderer.enabled = _showParticle;
    }

    public void Activation()
    {
        _spriteRenderer.enabled = true;
    }

    public void Deactivation()
    {
        _spriteRenderer.enabled = false;
    }
}
