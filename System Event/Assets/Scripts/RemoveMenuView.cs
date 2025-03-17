using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class RemoveMenuView : MonoBehaviour
{
    private ResourceType currentResourceType;
    private int currentCount;
    [SerializeField] private TMP_Dropdown resourceSecondDropdown;
    
    [SerializeField] private Button _removeButton;
    public void Show(Action<ResourceType, int> removeButtonCallBack)
    {
        gameObject.SetActive(true);
        _removeButton.onClick.AddListener(()=> removeButtonCallBack.Invoke(currentResourceType, currentCount));
        currentResourceType = (ResourceType)resourceSecondDropdown.value;
    }



}