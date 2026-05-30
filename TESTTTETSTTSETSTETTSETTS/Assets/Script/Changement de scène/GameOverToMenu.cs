using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverToMenu : MonoBehaviour
{

    public string nextSceneName = "Ecran d'acceuil";

    public void Load()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextSceneName);
    }
}
