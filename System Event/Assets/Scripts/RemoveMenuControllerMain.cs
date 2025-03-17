using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMenuControllerMain : UIController
{
    private ResourcePool _resourcePool;
    private RemoveMenuView _removeMenuView;
    public RemoveMenuControllerMain(UISwitcher switcher, RemoveMenuView removeMenuView, ResourcePool resourcePool) : base(switcher) { }

    public override void Enter()
    {
        // Логика при входе в состояние удаления ресурсов
        _removeMenuView.Show(RemoveResoursee);
        Debug.Log("Entered Remove Menu");
    }

    public override void Exit()
    {
        // Логика при выходе из состояния удаления ресурсов
        Debug.Log("Exited Remove Menu");
    }

    private void RemoveResoursee(ResourceType type, int count)
    {
        _resourcePool.DeductResource(type, count);
    }
}
