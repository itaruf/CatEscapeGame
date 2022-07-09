using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour, IPushable
{
    enum Direction { UP, BW, R, L};
    [SerializeField] Direction _direction;
    [SerializeField] float _speed;


    // Start is called before the first frame update
    void Start()
    {
        var v = this as IPushable;
        v.OnPush();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void IPushable.OnPush()
    {
        switch (_direction)
        {
            case Direction.UP:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(1, 0, 0)));
                break;
            case Direction.BW:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(1, 0, 0)));
                break;
            case Direction.R:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(1, 0, 0)));
                break;
            case Direction.L:
                StartCoroutine(PushAnim(transform.position, transform.position + new Vector3(1, 0, 0)));
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
    }
}
