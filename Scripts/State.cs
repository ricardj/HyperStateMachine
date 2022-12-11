using System;
using UnityEngine;

[Serializable]
public class State
{
    [SerializeField] string _stateName;
    [SerializeField] bool _isActive;


    public State(string stateName)
    {
        _stateName = stateName;
    }

    public bool IsState(string stateName)
    {
        return this._stateName == stateName;
    }

    public void SetActive()
    {
        _isActive = true;
    }

    public void SetDeactivated()
    {
        _isActive = false;
    }

    public string GetStateName()
    {
        return _stateName;
    }
    public bool IsState(State state)
    {
        return IsState(state.GetStateName());
    }

    public bool IsActive()
    {
        return _isActive;
    }
}
