using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {
    private GameObject manager;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Start() {
        manager = gameObject;
        AssignDontDestroy();
        startButton.onClick.AddListener(StartGame);
        startButton.onClick.AddListener(AddPauseHandler);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void AddPauseHandler() => manager.AddComponent<PauseHandler>();
    private void AssignDontDestroy() {
        DontDestroyOnLoad(manager);
    }
    private void QuitGame() {
        if (!quitButton)
            Debug.LogError($"{quitButton.name} hasn't been assigned.");
        Application.Quit();
    }
    private void StartGame() {
        if (!startButton)
            Debug.LogError($"{startButton.name} hasn't been assigned.");
        SceneManager.LoadScene("SampleScene");
    }
}
