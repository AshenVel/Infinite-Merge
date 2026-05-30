using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //public float CoefDefence;
    private GameObject Player;

    private GameObject WaveManager;

    public GameObject TilteDamage;

    public Transform ICI;

    private void Start()
    {
        ICI = transform.GetChild(0);

        WaveManager = GameObject.Find("WaveManager");
        Player = GameObject.Find("Player");
    }
    public void TakeDamage(float damage)
    {
        //CoefDefence = ((100f - GetComponent<ZombieScript>().Defence) / 100f);

        GetComponent<ZombieScript>().PV -= damage;
        GetComponent<Animator>().SetTrigger("DamageEnemy");

        GameObject Tilte = Instantiate(TilteDamage, ICI.position, transform.rotation);
        Tilte.transform.GetChild(0).GetComponent<Damage>().DoDamage(damage, gameObject);

        if (GetComponent<ZombieScript>().PV <= 0)
        {
            if (!GetComponent<ZombieBoom>())
            {
                Player.GetComponent<PlayerManager>().Xp += GetComponent<ZombieScript>().Xp;
                Player.GetComponent<PlayerManager>().ZombieKilled++;
                Destroy(gameObject);
            }

            else 
            {
                Player.GetComponent<PlayerManager>().Xp += GetComponent<ZombieScript>().Xp;
                Player.GetComponent<PlayerManager>().ZombieKilled++;
            }
        }
    }
}
