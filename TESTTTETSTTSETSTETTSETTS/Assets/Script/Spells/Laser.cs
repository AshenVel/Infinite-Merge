using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject Player;

    private float TimeIs = 0;

    private string Effect;

    public float Damage = 15;

    private void Start()
    {
        Player = GameObject.Find("Player");

        Effect = Player.GetComponent<SpellsManager>().LaserEffect;
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
