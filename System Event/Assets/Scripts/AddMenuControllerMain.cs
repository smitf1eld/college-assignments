using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMenuControllerMain : UIController
{
    private AddMenuView _addMenuView;

    public AddMenuControllerMain(UISwitcher switcher, AddMenuView addMenuView) : base(switcher)
    {
        _addMenuView = addMenuView;

    }

    public override void Enter()
    {
        // Логика при входе в состояние добавления ресурсов
        _addMenuView.Show();

    }
       

    public override void Exit()
    {
        _addMenuView.Hide();
    }
    
}
