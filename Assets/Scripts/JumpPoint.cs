using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpPoint : MonoBehaviour
{
    private GameObject _startLoc;
    [SerializeField] GameObject _landingLoc;

    [SerializeField] AnimationCurve _jumpCurve;

    [SerializeField] bool _activated;
    [SerializeField] float _speed;

    // Start is called before the first frame update
    void Awake()
    {
        if (!_landingLoc)
            _landingLoc = GetComponentInChildren<GameObject>(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
            return;

        PC._jump.action.started += PC.JumpInput;
        PC._jump.action.started += PC.MoveCanceled;
        PC._jump.action.started += JumpInput;

        _startLoc = collision.gameObject;

        PC._jumpIcon._rawImage.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerController PC))
            return;

        StopCoroutine(JumpAnim(_startLoc, _landingLoc));

        PC._jump.action.started -= PC.JumpInput;
        PC._jump.action.started -= PC.MoveCanceled;
        PC._jump.action.started -= JumpInput;

        PC._jumpIcon._rawImage.enabled = false;
    }

    public void JumpInput(InputAction.CallbackContext obj)
    {
        StartCoroutine(JumpAnim(_startLoc, _landingLoc));
    }

    IEnumerator JumpAnim(GameObject start, GameObject end)
    {
        float timeToStart = Time.time;
        var s = start.transform.position;
        var e = end.transform.position;

        while (Vector3.Distance(start.transform.position, e) > 0.05f)
        {
            start.transform.position = Vector3.Lerp(s, e + new Vector3(0, _jumpCurve.Evaluate(Time.time - timeToStart), 0), (Time.time - timeToStart) * _speed);

            yield return null;

        }
    }
}