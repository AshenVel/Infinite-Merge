using UnityEngine;

public class BallExplosion : MonoBehaviour
{
    private GameObject Player;

    private float TimeIs = 0;


    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ZombieScript>())
        {
            collision.GetComponent<HealthManager>().TakeDamage(20);
            collision.GetComponent<EffectManager>().ApplyEffect(Player.GetComponent<SpellsManager>().BallEffect);
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
