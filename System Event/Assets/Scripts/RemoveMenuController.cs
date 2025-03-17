using TMPro;
using UnityEngine;
using UnityEngine.UI;

//public class RemoveMenuController : MonoBehaviour
{
    public TMP_Dropdown resourceSecondDropdown;
    public TMP_InputField amountSecondInput;
    public Button addSecondButton;
    public MainMenuController uiController;

    void Start()
    {
        addSecondButton.onClick.AddListener(AddResource);
    }
    
    void AddResource()
    {
        // Получаем выбранный ресурс из Drop-down
        MainMenuController.ResourceType selectedResource = (MainMenuController.ResourceType)resourceSecondDropdown.value;

        // Получаем количество из InputField
        if (int.TryParse(amountSecondInput.text, out int amount))
        {
            // Добавляем количество к выбранному ресурсу
            uiController.DeductResource(selectedResource, amount);

            // Сбрасываем значения Drop-down и InputField на дефолтные
            resourceSecondDropdown.value = 0;
            amountSecondInput.text = "";
        }
        else
        {
            Debug.LogError("Invalid input. Please enter a valid integer.");
        }
    }
}
