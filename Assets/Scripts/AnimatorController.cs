using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected SpriteRenderer _sprite;
    public Dictionary<string, int> _animations = new Dictionary<string, int>();

    protected void Start()
    {
        foreach (var anim in _animator.runtimeAnimatorController.animationClips)
        {
            /*Debug.Log(anim.name);*/
            _animations.Add(anim.name, Animator.StringToHash(anim.name));
        }
    }

    private void FixedUpdate()
    {
    }

    public virtual void PlayAnimation(string name, bool value = true)
    {
        /*if (!_animations.ContainsKey(name))
            return;*/

        _animator.SetBool(name, value);
    }

    public virtual void TriggerAnimation(string name)
    {
        /*if (!_animations.ContainsKey(name))
            return;*/

        _animator.SetTrigger(name);
    }

    public virtual bool IsAnimPlaying(string name)
    {
        /*if (!_animations.ContainsKey(name))
            return false;*/

        return (_animator.GetCurrentAnimatorStateInfo(0).IsName(name));
    }

    public virtual void FlipSprite(Vector2 _direction)
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
