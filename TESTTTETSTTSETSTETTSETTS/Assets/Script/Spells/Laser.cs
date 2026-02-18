using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject Player;

    private bool Active = true;
    private float TimeIs = 0;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Active)
        {
            if (collision.GetComponent<ZombieScript>())
            {
                collision.GetComponent<HealthManager>().TakeDamage(15);
                collision.GetComponent<EffectManager>().ApplyEffect(Player.GetComponent<SpellsManager>().LaserEffect);
            }
        }
    }
    private void Update()
    {
        TimeIs += Time.deltaTime;
        if (TimeIs > 0.1f)
        {
            GetComponent<Animator>().SetBool("Disappear", true);
        }
        if (TimeIs > 1.2f)
        {
            Destroy(gameObject);
        }
    }
}
