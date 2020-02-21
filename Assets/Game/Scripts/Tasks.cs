using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private int _TasksTotal;
    [SerializeField] private int _TasksCompleted;
    [SerializeField] private bool _AllTasksCompleted;

    [Header("Tasks")]
    [SerializeField] private List<Task_Collect> _Collect = new List<Task_Collect>();

    private void Start()
    {
        _TasksTotal = _Collect.Count;
    }

    //Tasks
    public void Task_Collect_Add(string taskname)
    {
        CheckTasks_Collect(taskname);
        CheckTasks_TasksCompleted();
    }       //Collect

    //Check
    private void CheckTasks_Collect(string taskname)
    {
        for (int i = 0; i < _Collect.Count; i++)
        {
            if(_Collect[i]._TaskName == taskname && !_Collect[i]._Completed)
            {
                if (_Collect[i]._CurrentCollected < _Collect[i]._CollectAmount - 1)
                    _Collect[i]._CurrentCollected++;
                else
                {
                    _Collect[i]._CurrentCollected++;
                    _Collect[i]._Completed = true;
                }
            }
        }
    }    //Collect
    private void CheckTasks_TasksCompleted()
    {
        int taskscompleted = 0;
        for (int i = 0; i < _Collect.Count; i++)
        {
            if (_Collect[i]._Completed)
                taskscompleted++;
        }
        _TasksCompleted = taskscompleted;

        if (_TasksCompleted >= _TasksTotal)
            _AllTasksCompleted = true;
    }            //Tasks Completed

    //GetInfo
    public int Tasks_Total()
    {
        return _TasksTotal;
    }
    public int Tasks_Completed()
    {
        return _TasksCompleted;
    }
}

[System.Serializable]
public class Task_Collect
{
    public string _TaskName;
    public int _CollectAmount;
    public int _CurrentCollected;
    public bool _Completed;
}