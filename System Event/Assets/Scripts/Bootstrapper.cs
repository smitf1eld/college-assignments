using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private UISwitcher _uiSwitcher;
    private ResourcePool _resourcePool;
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private UISwitcherView uiSwitcherView;
    private AddMenuControllerMain _addMenuController;
    private AddMenuView _addMenuView;
    private MainMenuControllerMain _mainMenuController;
    private RemoveMenuControllerMain _removeMenuController;
    private RemoveMenuView _removeMenuView;

    void Start()
    {
        // Инициализация UISwitcher и других классов
        _uiSwitcher = new UISwitcher();
        _resourcePool = new ResourcePool();
        _addMenuController = new AddMenuControllerMain(_uiSwitcher, _resourcePool, _addMenuView);
        _mainMenuController = new MainMenuControllerMain(_uiSwitcher, _resourcePool, mainMenuView);
        _removeMenuController = new RemoveMenuControllerMain(_uiSwitcher, _removeMenuView, _resourcePool);
        

        // Переход в начальное состояние (например, MainMenu)
        _uiSwitcher.ChangeState(new MainMenuControllerMain(_uiSwitcher, _resourcePool, mainMenuView));
        
        mainMenuView.Construct(_resourcePool);
        uiSwitcherView.Construct(_uiSwitcher, _mainMenuController, _addMenuController, _removeMenuController);
        
    }
}
