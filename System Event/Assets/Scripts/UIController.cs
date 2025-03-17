public abstract class UIController
{
    protected UISwitcher _switcher;

    public UIController(UISwitcher switcher)
    {
        _switcher = switcher;
    }

    public abstract void Enter();
    public abstract void Exit();
}
