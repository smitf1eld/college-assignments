using System;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenView : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    
    public Button OpenButton => _openButton;

    public void SubscribeOpenButton(Action action)
    {
        _openButton.onClick.AddListener(() => action?.Invoke());
    }

    public void UnsubscribeOpenButton(Action action)
    {
        _openButton.onClick.RemoveListener(() => action?.Invoke());
    }
}