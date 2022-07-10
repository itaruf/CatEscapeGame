using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour, IPushable
{
    enum Direction { UP, BW, R, L};
    [SerializeField] Direction _direction;
    [SerializeField] float _speed =  2;
    [SerializeField] float _pushDistance = 1;

    bool _activated = true;
    // Start is called before the first frame update
    void Start()
    {
       /* var v = this as IPushable;
        v.OnPush();*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void IPushable.OnPush()
    {
        if (!_activated)
            return;

        switch (_direction)
        {
            case Direction.UP:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(_pushDistance, 0, 0)));
                break;
            case Direction.BW:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(_pushDistance, 0, 0)));
                break;
            case Direction.R:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(_pushDistance, 0, 0)));
                break;
            case Direction.L:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(_pushDistance, 0, 0)));
                break;
        }
    }

    IEnumerator PushAnim(Vector3 start, Vector3 end)
    {
        float timeToStart = Time.time;
        var s = start;
        var e = end;

        while (Vector3.Distance(start, e) > 0.05f)
        {
            transform.position = Vector3.Lerp(s, e, (Time.time - timeToStart) * _speed);

            yield return null;
        }

        _activated = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_activated)
            return;

        if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            var v = this as IPushable;
            PC._onPush += v.OnPush;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!_activated)
            return;

        if (collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            var v = this as IPushable;
            PC._onPush -= v.OnPush;
        }
    }
}
