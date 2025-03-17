using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitcher
{
    private UIController _currentController;

    public void ChangeState(UIController newController)
    {
        if (_currentController != null)
        {
            _currentController.Exit();
        }

        _currentController = newController;
        _currentController.Enter();
    }
}
