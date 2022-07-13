using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : AnimatorController
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    { 
    }

    public override void PlayAnimation(string name, bool value = true)
    {
        _animator.SetBool(name, value);
    }

    public override void TriggerAnimation(string name)
    { 
        _animator.SetTrigger(name);
    }

    public override bool IsAnimPlaying(string name)
    {
        return (_animator.GetCurrentAnimatorStateInfo(0).IsName(name));
    }
    public override void FlipSprite(Vector2 _direction)
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
