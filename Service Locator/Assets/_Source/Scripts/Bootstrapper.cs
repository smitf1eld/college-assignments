using _Sourse.Scripts.Interfaces;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MainScreenView _mainScreenView;
    [SerializeField] private PanelView _panelView;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _openSound;
    [SerializeField] private AudioClip _closeSound;

    private void Start()
    {
        var serviceLocator = new ServiceLocator();
        serviceLocator.AddService<IFadeService>(new FadeService());
        serviceLocator.AddService<ISoundPlayer>(new SoundPlayer(_audioSource, _openSound, _closeSound));
        
        serviceLocator.GetService<IFadeService>(out var fadeService);
        serviceLocator.GetService<ISoundPlayer>(out var soundPlayer);
        
        var mainScreenController = new MainScreenController(_mainScreenView, null);
        var panelController = new PanelController(_panelView, null, fadeService, soundPlayer);
        
        var uiSwitcher = new UISwitcher(mainScreenController, panelController);
        
        mainScreenController.SetUISwitcher(uiSwitcher);
        panelController.SetUISwitcher(uiSwitcher);
    }
}