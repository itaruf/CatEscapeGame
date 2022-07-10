using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Icon : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] Vector3 _offset;

    delegate void Delegate();
    Delegate _onActivation;
    Delegate _onDeactivation;

    public RectTransform _rectTransform;
    public RawImage _rawImage;

    void Awake()
    {
        TryGetComponent(out _rawImage);
        TryGetComponent(out _rectTransform);

        if (!_rawImage)
            return;

        _rawImage.enabled = false;
    }

    void FixedUpdate()
    {
        if (!_rectTransform)
            return;

        /*Debug.Log(_rectTransform.anchoredPosition);
        Debug.Log(_target.transform.position);*/

        // Relative
        /*Debug.Log(Camera.main.transform.InverseTransformPoint(transform.position));
        Debug.Log($"P : {Camera.main.transform.InverseTransformPoint(_target.transform.position)}");
        Debug.Log($"TP : {Camera.main.transform.TransformPoint(_target.transform.position)}");*/

        transform.position = Camera.main.transform.TransformPoint(_target.transform.position) + _offset;
        /*_rectTransform.anchoredPosition = Camera.main.transform.TransformPoint(_target.transform.position) + _offset;*/
    }

    public virtual void Activation()
    {
        _rawImage.enabled = true;
    }

    public virtual void Deactivation()
    {
        _rawImage.enabled = false;
    }
}
