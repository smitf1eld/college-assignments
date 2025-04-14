using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private CanvasGroup _canvasGroup;
    
    public Button CloseButton => _closeButton;
    public CanvasGroup CanvasGroup => _canvasGroup;

    public void SubscribeCloseButton(Action action)
    {
        _closeButton.onClick.AddListener(() => action?.Invoke());
    }

    public void UnsubscribeCloseButton(Action action)
    {
        _closeButton.onClick.RemoveListener(() => action?.Invoke());
    }
}