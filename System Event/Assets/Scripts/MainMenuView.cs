using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private GameObject _itemsPrefab;
    private ResourcePool _resourcePool;
    public RectTransform _rectTransformPanel;
    [SerializeField] private Button _resetButton;
    private ResourceItem _resourceItem;
    private bool _isInitialized = false; // Флаг инициализации

    private void Awake()
    {
        // Проверяем, что все необходимые компоненты назначены
        if (_itemsPrefab == null || _rectTransformPanel == null || _resetButton == null)
        {
            Debug.LogError("One or more components are not assigned in the inspector.");
            return;
        }
    }

    public void Show(Action resetButtonCallBack)
    {
        gameObject.SetActive(true);

        // Подписываемся на кнопку сброса
        _resetButton.onClick.RemoveAllListeners(); // Очищаем старые слушатели
        _resetButton.onClick.AddListener(() => resetButtonCallBack?.Invoke());

        // Инициализируем ресурсы, если это еще не сделано
        if (!_isInitialized)
        {
            InitializeResources();
            _isInitialized = true;
        }

        // Обновляем отображение ресурсов
        _resourcePool.UpdateResourceItems();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Construct(ResourcePool resourcePool, ResourceItem resourceItem)
    {
        _resourcePool = resourcePool;
        _resourceItem = resourceItem;
    }

    private void InitializeResources()
    {
        // Очищаем панель от старых элементов
        foreach (Transform child in _rectTransformPanel)
        {
            Destroy(child.gameObject);
        }

        // Создаем элементы для каждого типа ресурса
        foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType)))
        {
            GameObject item = Instantiate(_itemsPrefab, _rectTransformPanel);
            _resourceItem = item.GetComponent<ResourceItem>();

            if (_resourceItem != null)
            {
                // Устанавливаем название и количество ресурса
                _resourceItem.SetResource(type.ToString(), _resourcePool.GetResource((int)type));
            }
            else
            {
                Debug.LogError("ResourceItem component is missing on the prefab.");
            }
        }
    }
    
}