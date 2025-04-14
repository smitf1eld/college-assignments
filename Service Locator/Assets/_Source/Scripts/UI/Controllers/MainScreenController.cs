using System;

public class MainScreenController : IUIState
{
    private readonly MainScreenView _view;
    private UISwitcher _uiSwitcher;
    
    public event Action OnOpenButtonClicked;

    public MainScreenController(MainScreenView view, UISwitcher uiSwitcher)
    {
        _view = view;
        _uiSwitcher = uiSwitcher;
    }

    public void Enter()
    {
        _view.SubscribeOpenButton(HandleOpenButton);
        _view.OpenButton.interactable = true;
    }

    public void Exit()
    {
        _view.UnsubscribeOpenButton(HandleOpenButton);
        _view.OpenButton.interactable = false;
    }

    private void HandleOpenButton()
    {
        OnOpenButtonClicked?.Invoke();
    }
    
    public void SetUISwitcher(UISwitcher uiSwitcher)
    {
        _uiSwitcher = uiSwitcher;
    }
    
}