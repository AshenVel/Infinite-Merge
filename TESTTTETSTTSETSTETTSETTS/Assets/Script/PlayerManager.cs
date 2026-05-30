using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float Xp;
    public int ZombieKilled;
    public int Wave;
    public int Level;

    public Image HealthBar;

    public Image XpBar;

    public GameObject NumVague;

    public GameObject NumZombieKill;

    public GameObject UpgradeManager;

    public GameObject Village;

    public GameObject FeedbackIce;
    public GameObject FeedbackThunder;

    public GameObject Niv;

    private void Start()
    {
        Xp  = 0;
        ZombieKilled = 0;
        Wave = 0;
        Level = 1;
    }

    private void Update()
    {
        if(Xp >= Level * 5 + 1)
        {
            Xp = Xp - (Level * 5 + 1);
            Level++;

            Niv.GetComponent<TextMeshProUGUI>().text = "Niv : " + Level;

            if(Level == 5)
            {
                FeedbackIce.SetActive(true);
            }
            if(Level == 10)
            {
                FeedbackThunder.SetActive(true);
            }

            UpgradeManager.GetComponent<UpgradeManager>().Select();
        }
        HealthBar.fillAmount = Village.GetComponent<Village>().PV/ 100;

        XpBar.fillAmount = Xp / (Level * 5 + 1);

        NumVague.GetComponent<TextMeshProUGUI>().text = "Vague " + Wave;

        NumZombieKill.GetComponent<TextMeshProUGUI>().text = "" + ZombieKilled;
    }

}