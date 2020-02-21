using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private bool _UseTeleport;

    [Header("Settings")]
    [SerializeField] private float _MovementSpeed;
    [SerializeField] private float _HightOffset;


    [SerializeField] private Transform _TeleportPoint;

    void Start()
    {
        
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 tppos = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.T))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                tppos = new Vector3(hit.point.x,_HightOffset, hit.point.z);
            }
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            transform.position = tppos;
        }
    }
}
