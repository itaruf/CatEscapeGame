using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _sprite;
    public Dictionary<string, int> _animations = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var anim in _animator.runtimeAnimatorController.animationClips)
            _animations.Add(anim.name, Animator.StringToHash(anim.name));
    }

    private void FixedUpdate()
    { 
    }

    public void PlayAnimation(string name)
    {
        _animator.SetTrigger(_animations[name]);
    }

    public void TriggerAnimation(string name)
    {
        _animator.SetTrigger(_animations[name]);
    }

    public bool IsAnimPlaying(string name)
    {
        return (_animator.GetCurrentAnimatorStateInfo(0).IsName(name));
    }
    public void FlipSprite(Vector2 _direction)
    {
        switch (_direction)
        {
            case Vector2 v when v.Equals(Vector2.left):
                _sprite.flipX = true;
                break;
            case Vector2 v when v.Equals(Vector2.right):
                _sprite.flipX = false;
                break;
        }
    }
}
