using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMenuControllerMain : UIController
{
    private ResourcePool _resourcePool;
    private AddMenuView _addMenuView;

    public AddMenuControllerMain(UISwitcher switcher, ResourcePool resourses, AddMenuView addMenuView) : base(switcher)
    {
        _resourcePool = resourses;
        _addMenuView = addMenuView;

    }

    public override void Enter()
    {
        // Логика при входе в состояние добавления ресурсов
        _addMenuView.Show(AddResoursee);
        Debug.Log("Entered Add Menu");
    }

    public override void Exit()
    {
        _addMenuView.Hide();
        Debug.Log("Exited Add Menu");
    }

    private void AddResoursee(ResourceType type, int amount)
    {
        _resourcePool.AddResource(type, amount);
    }
}
