using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class MainMenuController : MonoBehaviour
{
    [HideInInspector] private VisualElement ui;

    [HideInInspector] private Button playButton;
    [HideInInspector] private Button optionsButton;
    [HideInInspector] private Button quitButton;

    [SerializeField] private string playButtonName;
    [SerializeField] private string optionsButtonName;
    [SerializeField] private string quitButtonName;

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        playButton = ui.Q<Button>(playButtonName);
        playButton.clicked += OnPlayButtonClicked;

        optionsButton = ui.Q<Button>(optionsButtonName);
        optionsButton.clicked += OnOptionsButtonClicked;

        quitButton = ui.Q<Button>(quitButtonName);
        quitButton.clicked += OnQuitButtonClicked;
    }

    private void OnPlayButtonClicked()
    {
        gameObject.SetActive(false);
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    private void OnOptionsButtonClicked()
    {
        Debug.Log("Options!");
    }
}
