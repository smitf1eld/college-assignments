public class UISwitcher
{
    private readonly MainScreenController _mainScreenController;
    private readonly PanelController _panelController;

    private IUIState _currentState;

    public UISwitcher(MainScreenController mainScreenController, PanelController panelController)
    {
        _mainScreenController = mainScreenController;
        _panelController = panelController;

        _mainScreenController.OnOpenButtonClicked += SwitchToPanel;
        _panelController.OnCloseButtonClicked += SwitchToMainScreen;

        SwitchToMainScreen();
    }

    private void SwitchToMainScreen()
    {
        SwitchState(_mainScreenController);
    }

    private void SwitchToPanel()
    {
        SwitchState(_panelController);
    }

    private void SwitchState(IUIState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}