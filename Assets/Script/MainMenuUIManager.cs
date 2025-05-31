using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var startButton = root.Q<Button>(className: "start");
        var exitButton = root.Q<Button>(className: "exit-button");

        if (startButton != null)
        {
            startButton.clicked += () =>
            {
                Debug.Log("Start tuþuna basýldý!");
                SceneManager.LoadScene("LV1");
            };
        }

        if (exitButton != null)
        {
            exitButton.clicked += () =>
            {
                Debug.Log("Oyundan çýkýlýyor...");
                Application.Quit();

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            };
        }
    }
}
