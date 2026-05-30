using UnityEngine;
public class FeedBack : MonoBehaviour
{
    public GameObject Feedback;

    public void Close()
    {
        Time.timeScale = 1f;
        Feedback.gameObject.SetActive(false);
    }
}
