using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private bool Go = false;

    private float TimeNow = 0;

    public GameObject parent;

    private GameObject UserNOW = null;

    public void DoDamage(float NbDamage, GameObject User)
    {
        UserNOW = User;
        Go = true;
        gameObject.GetComponent<TextMeshProUGUI>().text = NbDamage.ToString();
        gameObject.GetComponent<Animator>().SetTrigger("Fade");
    }


    private void Update()
    {
        if (UserNOW != null) 
        {
            parent.transform.position = UserNOW.GetComponent<HealthManager>().ICI.position;
        }
        if (Go) { TimeNow += Time.deltaTime; }
        

        if (TimeNow > 2) 
        { 
            Destroy(parent);
        }
    }
}
