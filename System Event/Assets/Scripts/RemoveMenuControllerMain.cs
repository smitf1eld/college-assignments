using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMenuControllerMain : UIController
{
    private RemoveMenuView _removeMenuView;

    public RemoveMenuControllerMain(UISwitcher switcher, RemoveMenuView removeMenuView) :
        base(switcher)
    {
        _removeMenuView = removeMenuView;
    }
    

    public override void Enter()
    {
        // Логика при входе в состояние удаления ресурсов
        _removeMenuView.Show();
    }

    public override void Exit()
    {
        // Логика при выходе из состояния удаления ресурсов
        _removeMenuView.Hide();
    }
    
}
