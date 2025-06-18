using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour {
    [SerializeField] private bool isPaused; 
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject pauseMenu;
    List<GameObject> pauseObjects = new();
    
    private delegate void ButtonHandler();
    private ButtonHandler onPauseButtonPressed;
    private void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        AssignValues();
    }
    private void AssignValues() {
        if (onPauseButtonPressed != null) return;
        onPauseButtonPressed += TogglePause;
        onPauseButtonPressed += TogglePauseVisibility;
        onPauseButtonPressed += ToggleTimeScale;
        resumeButton = GetButtonByTag("resume");
        pauseButton = GetButtonByTag("pauser");
        pauseMenu = resumeButton.transform.parent.gameObject;
        pauseButton.onClick.AddListener(CheckPaused);
        resumeButton.onClick.AddListener(CheckPaused);
        pauseObjects = GetChildrenOfPauseMenu();
    }
    private Button GetButtonByTag(string pTag, bool pActive = false) {
        foreach (Button obj in Resources.FindObjectsOfTypeAll<Button>())
        {
            if (obj.CompareTag(pTag) && !pActive)
            {
                return obj.GetComponent<Button>();
            }
        }
        return null;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        canvas = FindObjectOfType<Canvas>();
        AssignValues();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            onPauseButtonPressed?.Invoke();
        }
    }
    private List<GameObject> GetChildrenOfPauseMenu() {
        var children = new List<GameObject>();
        foreach (Transform child in pauseMenu.transform) {
            children.Add(child.gameObject);
        }
        return children;
    }
    private void CheckPaused() {
        onPauseButtonPressed?.Invoke();
    }
    private void TogglePause() => isPaused = !isPaused;

    private void TogglePauseVisibility() {
        pauseObjects.ForEach(obj => obj.SetActive(isPaused));
        pauseButton.gameObject.SetActive(!isPaused);
    }
    private void ToggleTimeScale() => Time.timeScale = isPaused ? 0f : 1f;
}
