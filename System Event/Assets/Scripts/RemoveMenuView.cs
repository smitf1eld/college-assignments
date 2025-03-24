using UnityEngine;
using System;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RemoveMenuView : MonoBehaviour
{
    private ResourceType _currentResourceType;
    private int _currentCount;
    private ResourcePool _currentResourses;
    [SerializeField] private TMP_Dropdown resourceSecondDropdown;
    [SerializeField] private TMP_InputField amountSecondInput;
    [SerializeField] private Button removeButton;
    private Action<ResourceType, int> _removeButtonCallBack;
    private void Awake()
    {
        removeButton.onClick.AddListener(OnRemoveButtonClicked);
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Construct(ResourcePool resourcePool)
    {
        _currentResourses = resourcePool;
    }
    
    private void OnRemoveButtonClicked()
    {
        ResourceType resourceType = (ResourceType)resourceSecondDropdown.value;

        if (int.TryParse(amountSecondInput.text, out int amount))
        {
            // Вычитаем количество к выбранному ресурсу
            _currentResourses.DeductResource(resourceType, amount);

            // Вызываем колбэк
            _removeButtonCallBack?.Invoke(resourceType, amount);

            // Сбрасываем значения Drop-down и InputField на дефолтные
            resourceSecondDropdown.value = 0;
            amountSecondInput.text = "";
        }
        else
        {
            Debug.LogError("Invalid input. Please enter a valid integer.");
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}