using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {
    // Variables
    [SerializeField] private float timeLeft;
    // Properties
    private void Awake() {
        if (timeLeft <= 0) {
            timeLeft = 120f;
        }
    }
    private void Update() {
        if (!WaveManager.Instance.HasStarted) return;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f) {
            EndGame();
        }
    }
    private float GetTime() => timeLeft;
    private void EndGame() {
        SceneManager.LoadScene($"ScoreScreen");
    }
}