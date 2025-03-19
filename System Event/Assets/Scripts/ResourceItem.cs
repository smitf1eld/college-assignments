using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceItem : MonoBehaviour
{
    public TMP_Text resourceName;
    public TMP_Text resourceAmount;

    // Метод для установки названия и количества ресурса
    public void SetResource(string name, int amount)
    {
        resourceName.text = name;
        resourceAmount.text = amount.ToString();
    }
}
