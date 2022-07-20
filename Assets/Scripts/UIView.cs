using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private GameObject RestartPanel;
    [SerializeField] private GameObject CompletePanel;

    public void Start()
    {
        CloseAllPanels();
    }

    public void OpenRestartPanel()
    {
        UIPanel.SetActive(true);
        RestartPanel.SetActive(true);
        CompletePanel.SetActive(false);
    }

    public void OpenCompletePanel()
    {
        UIPanel.SetActive(true);
        RestartPanel.SetActive(false);
        CompletePanel.SetActive(true);
    }

    public void CloseAllPanels()
    {
        UIPanel.SetActive(false);
        RestartPanel.SetActive(false);
        CompletePanel.SetActive(false);
    }
}
