using System;
using UnityEngine;
using UnityEngine.UI;

public class UISwitcherView : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button addMenuButton;
    [SerializeField] private Button removeMenuButton;
    private UISwitcher _uiSwitcher;
    private MainMenuControllerMain _mainMenuController;
    private AddMenuControllerMain _addMenuController;
    private RemoveMenuControllerMain _removeMenuController;
    


    private void Awake()
    {
        mainMenuButton.onClick.AddListener(()=> _uiSwitcher.ChangeState(_mainMenuController));
        addMenuButton.onClick.AddListener(()=> _uiSwitcher.ChangeState(_addMenuController));
        removeMenuButton.onClick.AddListener(()=> _uiSwitcher.ChangeState(_removeMenuController));
    }
    
    public void Construct(UISwitcher uiSwitcher, MainMenuControllerMain mainMenuControllerMain, 
        AddMenuControllerMain addMenuControllerMain, RemoveMenuControllerMain removeMenuControllerMain)
    {
        _uiSwitcher = uiSwitcher;
        _mainMenuController = mainMenuControllerMain;
        _addMenuController = addMenuControllerMain;
        _removeMenuController = removeMenuControllerMain;


    }
}