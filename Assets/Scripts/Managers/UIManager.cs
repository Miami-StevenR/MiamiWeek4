using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button pauseButton;
    [SerializeField]
    private Text pauseText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText(GameManager.CurrentState);
        GameManager.StateChanged.AddListener(UpdateText);
        pauseButton.onClick.AddListener(PausedClicked);
    }

    private void PausedClicked()
    {
        GameManager.TogglePause();
        Debug.Log("Pause Clicked");
    }

    private void OnDestroy()
    {
        GameManager.StateChanged.RemoveListener(UpdateText);
    }

    private void UpdateText(GameManager.State currentGameState)
    {
        if (currentGameState == GameManager.State.Running)
        {
            pauseText.text = "Pause";
        }
        else
        {
            pauseText.text = "Play";
        }
    }
}
