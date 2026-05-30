using UnityEngine;

public class BallExplosion : MonoBehaviour
{
    private GameObject Player;

    private string Effect;

    private float TimeIs = 0;

    public float Damage = 20;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Effect = Player.GetComponent<SpellsManager>().BallEffect; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ZombieScript>())
        {
            collision.GetComponent<HealthManager>().TakeDamage(Damage);
            collision.GetComponent<EffectManager>().ApplyEffect(Effect);
        }
    }

    private void Update()
    {
        if (Effect == "fire")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (Effect == "ice")
        {
            GetComponent<SpriteRenderer>().color = Color.lightBlue;
        }
        else if (Effect == "thunder")
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
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
