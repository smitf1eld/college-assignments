using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public enum ResourceType
{
    Cats,
    Cream,
    Cusions
}
public class ResourcePool
{

    public int[] resources = new int[3];
    
    public TMP_Text catsText;
    public TMP_Text creamText;
    public TMP_Text cusionsText;
    public Button resetButton;
    
    void Start()
    {
        resources[(int)ResourceType.Cats] = 5;
        resources[(int)ResourceType.Cream] = 10;
        resources[(int)ResourceType.Cusions] = 15;
        
        UpdateResourceUI();
        
    }
    public void ResetResources()  // Метод для сброса ресурсов
    {
        resources[(int)ResourceType.Cats] = 0;
        resources[(int)ResourceType.Cream] = 0;
        resources[(int)ResourceType.Cusions] = 0;
        
        UpdateResourceUI();
    }

    public void AddResource(ResourceType type, int amount)
    {
        resources[(int)type] += amount;
        UpdateResourceUI();
    }
    void UpdateResourceUI()     // Метод для обновления ресурсов
    {
        catsText.text = "Cats: " + resources[(int)ResourceType.Cats];
        creamText.text = "Cream: " + resources[(int)ResourceType.Cream];
        cusionsText.text = "Cusions: " + resources[(int)ResourceType.Cusions];
    }
    
    public void DeductResource(ResourceType type, int amount)
    {
        if (amount <= resources[(int)type])
        {
            resources[(int)type] -= amount;
        }
        else
        {
            resources[(int)type] = 0;
        }
        UpdateResourceUI();
    }

    public int GetResource(int index)
    {
        return resources[index];
    }
}
