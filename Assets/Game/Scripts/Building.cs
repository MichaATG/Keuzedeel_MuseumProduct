using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private List<Building_BuildLocation> _BuildLocation = new List<Building_BuildLocation>();
    [SerializeField] private bool _BuidingDone;

    public void SetObject(GameObject obj)
    {
        for (int i = 0; i < _BuildLocation.Count; i++)
        {
            if(_BuildLocation[i]._NeededObject == obj)
            {
                if (!_BuildLocation[i]._OnLocation)
                {
                    Destroy(obj.GetComponent<Rigidbody>());
                    obj.transform.position = _BuildLocation[i]._BuildLocation.transform.position;
                    obj.transform.rotation = _BuildLocation[i]._BuildLocation.transform.rotation;
                    _BuildLocation[i]._BuildLocation.SetActive(false);
                    _BuildLocation[i]._OnLocation = true;
                }
            }
        }

        CheckBuildingComplete();
    }

    private void CheckBuildingComplete()
    {
        int checkcomplete = 0;
        for (int i = 0; i < _BuildLocation.Count; i++)
        {
            if (_BuildLocation[i]._OnLocation)
                checkcomplete++;
        }
        if (checkcomplete == _BuildLocation.Count)
            _BuidingDone = true;
    }
}

[System.Serializable]
public class Building_BuildLocation
{
    public GameObject _BuildLocation;
    public GameObject _NeededObject;
    public bool _OnLocation;
}