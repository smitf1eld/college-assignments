using TMPro;
using UnityEngine;
using UnityEngine.UI;

//public class AddMenuController : MonoBehaviour
{
    public TMP_Dropdown resourceDropdown;
    public TMP_InputField amountInput;
    public Button addButton;
    public MainMenuController uiController;

    void Start()
    {
        addButton.onClick.AddListener(AddResource);
    }
    
    void AddResource()
    {
        // Получаем выбранный ресурс из Drop-down
        MainMenuController.ResourceType selectedResource = (MainMenuController.ResourceType)resourceDropdown.value;

        // Получаем количество из InputField
        if (int.TryParse(amountInput.text, out int amount))
        {
            // Добавляем количество к выбранному ресурсу
            uiController.AddResource(selectedResource, amount);

            // Сбрасываем значения Drop-down и InputField на дефолтные
            resourceDropdown.value = 0;
            amountInput.text = "";
        }
        else
        {
            Debug.LogError("Invalid input. Please enter a valid integer.");
        }
    }
}
