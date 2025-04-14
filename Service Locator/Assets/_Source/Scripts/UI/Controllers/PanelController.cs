using System;
using _Sourse.Scripts.Interfaces;

public class PanelController : IUIState
{
    private readonly PanelView _view;
    private UISwitcher _uiSwitcher;
    private readonly IFadeService _fadeService;
    private readonly ISoundPlayer _soundPlayer;
    
    public event Action OnCloseButtonClicked;

    public PanelController(PanelView view, UISwitcher uiSwitcher, IFadeService fadeService, ISoundPlayer soundPlayer)
    {
        _view = view;
        _uiSwitcher = uiSwitcher;
        _fadeService = fadeService;
        _soundPlayer = soundPlayer;
    }

    public void Enter()
    {
        _view.SubscribeCloseButton(HandleCloseButton);
        _fadeService.FadeIn(_view.CanvasGroup, 0.3f);
        _soundPlayer.PlayOpenSound();
    }

    public void Exit()
    {
        _view.UnsubscribeCloseButton(HandleCloseButton);
        _fadeService.FadeOut(_view.CanvasGroup, 0.3f);
        _soundPlayer.PlayCloseSound();
    }

    private void HandleCloseButton()
    {
        OnCloseButtonClicked?.Invoke();
    }
    public void SetUISwitcher(UISwitcher uiSwitcher)
    {
        _uiSwitcher = uiSwitcher;
    }
    
    
}