using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Start() {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
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
