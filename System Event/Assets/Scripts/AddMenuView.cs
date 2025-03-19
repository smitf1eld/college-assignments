using System;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class AddMenuView : MonoBehaviour
{
    [SerializeField] private Button addButton;
    [SerializeField] private TMP_Dropdown resourceFirstDropdown;
    [SerializeField] private TMP_InputField amountFirstInput;

    private ResourcePool _currentResources;
    private Action<ResourceType, int> _addButtonCallBack;

    private void Awake()
    {
        // Добавляем слушатель на кнопку один раз
        addButton.onClick.AddListener(OnAddButtonClicked);
    }

    public void Show(Action<ResourceType, int> addButtonCallBack)
    {
        gameObject.SetActive(true);
        _addButtonCallBack = addButtonCallBack;
    }

    public void Construct(ResourcePool resourcePool)
    {
        _currentResources = resourcePool;
    }

    private void OnAddButtonClicked()
    {
        // Получаем текущий выбранный тип ресурса
        ResourceType resourceType = (ResourceType)resourceFirstDropdown.value;

        // Проверяем ввод
        if (int.TryParse(amountFirstInput.text, out int amount))
        {
            if (amount < 0)
            {
                Debug.LogError("Amount cannot be negative.");
                return;
            }

            // Добавляем ресурсы
            _currentResources.AddResource(resourceType, amount);

            // Вызываем колбэк
            _addButtonCallBack?.Invoke(resourceType, amount);

            // Сбрасываем значения Dropdown и InputField
            resourceFirstDropdown.value = 0;
            amountFirstInput.text = "";
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