using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelsPanel;
    public GameObject settingsPanel;

    public List<GameObject> activePanels = new List<GameObject>();

    void Start()
    {
        ActivatePanel(mainPanel);

        levelsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        // int currentLevel = 
    }
    void ActivatePanel(GameObject panel)
    {
        //wykonalo sie
        panel.SetActive(true);
        activePanels.Add(panel);
    }

    void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
        activePanels.Remove(panel);
    }

    public void ChooseLevel()
    {
        ActivatePanel(levelsPanel);
        mainPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        ActivatePanel(settingsPanel);
        mainPanel.SetActive(false);
    }



    public void GoBack()
    {
        //deactivate current
        int currentIndex = activePanels.Count - 1;
        DeactivatePanel(activePanels[currentIndex]);

        //activate previous
        int previousIndex = currentIndex - 1;
        ActivatePanel(activePanels[previousIndex]);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
