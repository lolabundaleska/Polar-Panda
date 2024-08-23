using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionEvent : MonoBehaviour
{
    public UnityEvent unityEvent;

    public void CallEvent()
    {
        unityEvent.Invoke();
    }
}
