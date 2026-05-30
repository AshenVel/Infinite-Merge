using TMPro;
using UnityEngine;

public class Village : MonoBehaviour
{
    public float PV = 100;

    public GameObject GameOver;

    public GameObject KilledZombie;
    public GameObject Niv;
    public GameObject Vague;

    private GameObject Player;

    public TextMeshProUGUI TextHealth;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {

            if (!collision.gameObject.GetComponent<ZombieBoom>())
            {
                TakeDamage(collision.GetComponent<ZombieScript>().DamageVillage);
            }
            collision.GetComponent<ZombieScript>().PV = -1;
            collision.GetComponent<HealthManager>().TakeDamage(1);
        }
    }

    public void Heal(int Health)
    {
        PV += Health;
        GetComponent<Animator>().SetTrigger("HealVillage");

        if (PV > 100)
        {
            PV = 100;
        }
    }

    public void TakeDamage(float damage)
    {
        PV -= damage;
        GetComponent<Animator>().SetTrigger("DamageVillage");
        if (PV <= 0) { EndGame(); }
    }

    private void EndGame()
    {
        KilledZombie.GetComponent<TextMeshProUGUI>().text = " Zombies tues : " + Player.GetComponent<PlayerManager>().ZombieKilled;
        Niv.GetComponent<TextMeshProUGUI>().text = " Niveau atteint : " + Player.GetComponent<PlayerManager>().Level;
        Vague.GetComponent<TextMeshProUGUI>().text = " Vague atteinte : " + Player.GetComponent<PlayerManager>().Wave;
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }


    private void Update()
    {
        TextHealth.text = PV + "/100";
    }
}
