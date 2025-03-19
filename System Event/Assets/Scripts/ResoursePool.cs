using System;
using UnityEngine;

public enum ResourceType
{
    Cats,
    Cream,
    Cusions
}

public class ResourcePool
{
    private readonly MainMenuView _mainMenuView;
    public int[] resources;

    public event Action OnResourcesUpdated;

    public ResourcePool(MainMenuView mainMenuView)
    {
        if (mainMenuView == null)
        {
            Debug.LogError("MainMenuView cannot be null.");
            return;
        }
        _mainMenuView = mainMenuView;
        resources = new int[System.Enum.GetValues(typeof(ResourceType)).Length];
        
        resources[(int)ResourceType.Cats] = 5;
        resources[(int)ResourceType.Cream] = 10;
        resources[(int)ResourceType.Cusions] = 15;
        UpdateResourceItems();
    }

    
    
    

    public void ResetResources()
    {
        resources[(int)ResourceType.Cats] = 0;
        resources[(int)ResourceType.Cream] = 0;
        resources[(int)ResourceType.Cusions] = 0;
        UpdateResourceItems();
    }

    public void AddResource(ResourceType type, int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("Amount cannot be negative.");
            return;
        }
        resources[(int)type] += amount;
        UpdateResourceItems();
    }

    public void DeductResource(ResourceType type, int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("Amount cannot be negative.");
            return;
        }
        resources[(int)type] = Mathf.Max(0, resources[(int)type] - amount);
        UpdateResourceItems();
    }

    // В классе ResourcePool
    public int GetResource(int type)
    {
        return resources[(int)type];
    }

    public void SetResource(ResourceType type, int value)
    {
        if (value < 0)
        {
            Debug.LogError("Resource value cannot be negative.");
            return;
        }
        resources[(int)type] = value;
        UpdateResourceItems();
    }

    public void UpdateResourceItems()
    {
        foreach (Transform child in _mainMenuView._rectTransformPanel)
        {
            ResourceItem resourceItem = child.GetComponent<ResourceItem>();
            if (resourceItem != null)
            {
                if (System.Enum.TryParse(resourceItem.resourceName.text, out ResourceType type))
                {
                    resourceItem.SetResource(type.ToString(), resources[(int)type]);
                }
                else
                {
                    Debug.LogError($"Failed to parse resource type: {resourceItem.resourceName.text}");
                }
            }
        }
        OnResourcesUpdated?.Invoke();
    }
}