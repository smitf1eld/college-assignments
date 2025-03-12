using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    
    public void MainMenuPanelSwitcher()
    {
        // Если панель 1 активна, закрываем её, иначе открываем
        panel1.SetActive(!panel1.activeSelf);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }
    
    public void AddMenuPanelSwitcher()
    {
        // Если панель 2 активна, закрываем её, иначе открываем
        panel2.SetActive(!panel2.activeSelf);
        panel1.SetActive(false);
        panel3.SetActive(false);
    }
    
    public void RemoveMenuPanelSwitcher()
    {
        // Если панель 3 активна, закрываем её, иначе открываем
        panel3.SetActive(!panel3.activeSelf);
        panel1.SetActive(false);
        panel2.SetActive(false);
    }
}
