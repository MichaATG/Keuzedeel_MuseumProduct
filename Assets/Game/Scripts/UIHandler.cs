using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Tasks _TasksScript;
    [SerializeField] private List<UIHandler_VisualizeTask> _UIVisualize = new List<UIHandler_VisualizeTask>();


    private void Update()
    {
        for (int i = 0; i < _UIVisualize.Count; i++)
        {
            _UIVisualize[i]._TaskText.text = _TasksScript.Tasks_GetCollectedAmount(_UIVisualize[i]._TaskName).ToString() + " / " + _TasksScript.Tasks_GetTotalAmount(_UIVisualize[i]._TaskName).ToString();
        }
    }
}

[System.Serializable]
public class UIHandler_VisualizeTask
{
    public string _TaskName;
    public TextMeshProUGUI _TaskText;
}