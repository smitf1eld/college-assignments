using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private GameObject _itemsPrefab;
    private ResourcePool _resourcePool;
    [SerializeField] private Button _resetButton;

    public void Show(Action resetButtonCallBack)
    {
        gameObject.SetActive(true);
        _itemsPrefab.SetActive(true);
        
        for (int i = 0; i < _resourcePool.resources.Length; i++)
        {
            Vector3 position = new Vector3(i + 650, 0, 0);
            Instantiate(_itemsPrefab, position, Quaternion.identity);
        }
        
        _resetButton.onClick.AddListener(()=> resetButtonCallBack.Invoke());
        
    }

    public void Construct(ResourcePool resourcePool)
    {
        _resourcePool = resourcePool;
    }
}