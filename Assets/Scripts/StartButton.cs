using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;
    private SceneManagement sceneManagement;

    void Start()
    {
        sceneManagement = SceneManagement.instance;
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { sceneManagement.LoadGameScene(); });
    }
}