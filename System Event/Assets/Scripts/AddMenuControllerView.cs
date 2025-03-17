using System;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class AddMenuView : MonoBehaviour
{
    private ResourceType currentResourceType;
    private int currentCount;
    [SerializeField] private Button _addButton;
    public void Show(Action<ResourceType, int> addButtonCallBack)
    {
        gameObject.SetActive(true);
        _addButton.onClick.AddListener(()=> addButtonCallBack.Invoke(currentResourceType, currentCount));
    }
}