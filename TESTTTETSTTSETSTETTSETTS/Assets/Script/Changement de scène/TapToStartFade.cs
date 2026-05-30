using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TapToStartFade : MonoBehaviour
{
    public GameObject Tilte;
    public GameObject Touch;


    public string nextSceneName = "SceneJeu";
    //public Image fadeImage;
    public float fadeDuration = 0.5f;
        
    bool isLoading = false;

    void Update()
    {
        if (isLoading) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began
            || Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FadeAndLoad());
            GetComponent<Animator>().SetTrigger("Change");
            Tilte.GetComponent<Animator>().SetTrigger("Change");
            Touch.GetComponent<Animator>().SetTrigger("Change");
        }
    }

    IEnumerator FadeAndLoad()
    {
        isLoading = true;

        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            //fadeImage.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
