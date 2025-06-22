using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {
    // Variables
    [SerializeField] private float timeLeft;
    // Properties
    public static TimeManager Instance { get; private set; }
    private void Awake() {
        if (!Instance) {
            Instance = this;
        }
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