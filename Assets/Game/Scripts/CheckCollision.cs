using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public enum Options { OnTriggerEnter, OnTriggerExit, OnCollisionEnter, OnCollisionExit }
    [SerializeField] private Options _Options;

    [Header("Use name/tag to check object")]
    [SerializeField] private bool _UseTag;
    [SerializeField] private string _NeededObject;

    [Header("Event")]
    [SerializeField] private UnityEvent _UnityEvent;

    //Check Collision/Triggers
    public void OnTriggerEnter(Collider other)
    {
        if (_Options == Options.OnTriggerEnter)
        {
            if (!_UseTag)
            {
                if (other.name == _NeededObject)
                    _UnityEvent.Invoke();
            }
            else
                if (other.tag == _NeededObject)
                _UnityEvent.Invoke();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (_Options == Options.OnTriggerExit)
        {
            if (!_UseTag)
            {
                if (other.name == _NeededObject)
                    _UnityEvent.Invoke();
            }
            else
                if (other.tag == _NeededObject)
                _UnityEvent.Invoke();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (_Options == Options.OnCollisionEnter)
        {
            if (!_UseTag)
            {
                if (collision.gameObject.name == _NeededObject)
                    _UnityEvent.Invoke();
            }
            else
                if (collision.gameObject.tag == _NeededObject)
                _UnityEvent.Invoke();
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (_Options == Options.OnCollisionExit)
        {
            if (!_UseTag)
            {
                if (collision.gameObject.name == _NeededObject)
                    _UnityEvent.Invoke();
            }
            else
                if (collision.gameObject.tag == _NeededObject)
                _UnityEvent.Invoke();
        }
    }
}
