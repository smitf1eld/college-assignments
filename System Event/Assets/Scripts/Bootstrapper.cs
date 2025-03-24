using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private UISwitcher _uiSwitcher;
    private ResourcePool _resourcePool;
    private ResourceItem _resourceItem;
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private UISwitcherView uiSwitcherView;
    [SerializeField] private RemoveMenuView removeMenuView;
    [SerializeField] private AddMenuView addMenuView;
    private AddMenuControllerMain _addMenuController;
    private MainMenuControllerMain _mainMenuController;
    private RemoveMenuControllerMain _removeMenuController;
    

    void Start()
    {
        // Инициализация UISwitcher и других классов
        _uiSwitcher = new UISwitcher();
        _resourcePool = new ResourcePool(mainMenuView);
        _addMenuController = new AddMenuControllerMain(_uiSwitcher, addMenuView);
        _mainMenuController = new MainMenuControllerMain(_uiSwitcher, _resourcePool, mainMenuView);
        _removeMenuController = new RemoveMenuControllerMain(_uiSwitcher, removeMenuView);
        

        // Переход в начальное состояние (например, MainMenu)
        mainMenuView.Construct(_resourcePool, _resourceItem);
        uiSwitcherView.Construct(_uiSwitcher, _mainMenuController, _addMenuController, _removeMenuController);
        removeMenuView.Construct(_resourcePool);
        addMenuView.Construct(_resourcePool);
        
        
        
    }
}
