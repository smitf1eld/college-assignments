using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObservableSO<T> : ScriptableObject where T : IGameEventListener
{
    private List<T> _observers = new();

    public void AddListener(T observer)
    {
        _observers.Add(observer);
    }
    
    public void RemoveListener(T observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Notify();
        }
    }
}

public interface IGameEventListener
{
    void Notify();
}
[CreateAssetMenu(fileName = "ObservableSO", menuName = "SO/New Custom Event/AddEvent")]
public class AddEventSO : ObservableSO<IAddEventListener> { }


public interface IAddEventListener : IGameEventListener { }

public class AddMenuState : UISwitcher, IAddEventListener
{
    private AddEventSO _addEvent;
    private ResourcePool _resourcePool;

    public void Enter()
    {
        _addEvent.AddListener(this);
    }

    public void Exit()
    {
        _addEvent.RemoveListener(this);
    }
    
    public void Notify()
    {
        //_resourcePool.AddResource();
    }
}