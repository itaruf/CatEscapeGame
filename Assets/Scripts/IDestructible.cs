using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestructible
{
    public void OnDestroyed();
    public bool IsActivated();
}
