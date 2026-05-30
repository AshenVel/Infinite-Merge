using UnityEngine;

public class PlayAndPauseManager : MonoBehaviour
{
    public GameObject Pause;

    public void DoPause()
    {
        Pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DoPlay()
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
    }


}
