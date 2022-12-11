using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class StateEvent : UnityEvent<State> { }
[Serializable]
public class StateMachine
{
    public StateEvent OnStateActivated;
    public StateEvent OnStateDeactivated;

    [SerializeField] List<State> _states;
    [SerializeField] State _currentActiveState;

    public bool IsStateActive(string state)
    {
        return _currentActiveState.IsState(state);

    }
    public bool IsStateActive(State state)
    {
        return _currentActiveState.IsState(state);
    }

    public void SetActiveState(string state)
    {
        State foundState = GetState(state);
        if (foundState != null)
        {
            SetActiveState(foundState);
        }
        else
        {
            State newState = new State(state);
            _states.Add(newState);
            SetActiveState(newState);

        }
    }

    private State GetState(string state)
    {
        return _states.Find(s => s.IsState(state));
    }

    private void SetActiveState(State targetState)
    {

        for (int i = 0; i < _states.Count; i++)
        {
            State currentState = _states[i];
            if (!currentState.IsState(targetState))
            {
                if (currentState.IsActive())
                {
                    currentState.SetDeactivated();
                    OnStateDeactivated.Invoke(currentState);
                }
            }
        }
        _currentActiveState = targetState;
        targetState.SetActive();
        OnStateActivated.Invoke(targetState);
    }
}
