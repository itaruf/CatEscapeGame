using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{
    [SerializeField] Transform _jumpEnd;
    // Start is called before the first frame update
    void Awake()
    {
        if (!_jumpEnd)
            _jumpEnd = GetComponentInChildren<Transform>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
        {
            PC._jump.action.started -= PC.JumpInput;
            PC._jump.action.started -= PC.MoveCanceled;
            return;
        }

        PC._jump.action.started += PC.JumpInput;
        PC._jump.action.started += PC.MoveCanceled;
    }
}
