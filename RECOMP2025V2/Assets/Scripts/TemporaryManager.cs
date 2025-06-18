using Unity.VisualScripting;
using UnityEngine;

public class TemporaryManager : MonoBehaviour{
    private void Start() {
        if (StaticManager.Instance == null) {
            gameObject.AddComponent<StaticManager>();
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
    }
}