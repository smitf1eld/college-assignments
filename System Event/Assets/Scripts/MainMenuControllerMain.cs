using UnityEngine;

public class MainMenuControllerMain : UIController
{
    private ResourcePool _resourcePool;
    private MainMenuView _mainMenuView;
    
    public MainMenuControllerMain(UISwitcher switcher, ResourcePool resourcePool, MainMenuView mainMenuView) : base(switcher)
    {
        _resourcePool = resourcePool;
        _mainMenuView = mainMenuView;
    }

    public override void Enter()
    {
        // Логика при входе в состояние главного меню
        _mainMenuView.Show(ResetResourse);
        Debug.Log("Entered Main Menu");
    }

    public override void Exit()
    {
        // Логика при выходе из состояния главного меню
       
        Debug.Log("Exited Main Menu");
    }

    private void ResetResourse()
    {
        _resourcePool.ResetResources();
    }
}
