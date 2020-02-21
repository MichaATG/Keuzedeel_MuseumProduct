using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private float _Health;
    [SerializeField] private float _MaxHealth;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DebugLog(string debugmessage)
    {
        Debug.Log(debugmessage);
    }

    public float GetHealth()
    {
        return _Health;
    }
    public float GetMaxHealth()
    {
        return _MaxHealth;
    }
}
