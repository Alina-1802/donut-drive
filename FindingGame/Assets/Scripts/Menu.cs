using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelsPanel;
    public GameObject settingsPanel;

    public GameObject nextLevelButton;

    public List<GameObject> activePanels = new List<GameObject>();

    public GameManager gameManager;

    static int currentLevelIndex = 1;

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
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void EnableLevelsButtons()
    {
        Transform levelsPanelTransform = levelsPanel.transform;
        List<GameObject> childrenList = new List<GameObject>();

        foreach (Transform childTransform in levelsPanelTransform)
        {
            childrenList.Add(childTransform.gameObject);
        }

        foreach (GameObject obj in childrenList)
        {
            string text = obj.GetComponentInChildren<TextMeshProUGUI>().text;

            if (int.TryParse(text, out int number))
            {
                if (number <= currentLevelIndex)
                {
                    obj.GetComponent<Button>().enabled = true;
                }
            }
        }
    }

    public bool CheckNextLevelButtonActivation()
    {
        if (gameManager.GetNumberCompletedLevels() > SceneManager.GetActiveScene().buildIndex - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ActivateNextLevelButton()
    {
        nextLevelButton.SetActive(true);
    }

    public void ChooseLevel()
    {
        ActivatePanel(levelsPanel);
        mainPanel.SetActive(false);

        EnableLevelsButtons();
    }

    public void PlaySpecificLevel(GameObject button)
    {
        string stringSceneNumber = button.GetComponentInChildren<TextMeshProUGUI>().text;
        int sceneNumber = Int32.Parse(stringSceneNumber);

        SceneManager.LoadScene(sceneNumber);
    }


    public void ShowSettings()
    {
        ActivatePanel(settingsPanel);
        mainPanel.SetActive(false);
    }

    private void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
        activePanels.Add(panel);
    }

    private void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
        activePanels.Remove(panel);
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

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void IncreaseCurrentLevelIndex()
    {
        currentLevelIndex++;
    }

    public int GetCurrentLevelIndex()
    {
        return currentLevelIndex;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
