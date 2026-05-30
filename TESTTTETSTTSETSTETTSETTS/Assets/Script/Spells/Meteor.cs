
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private GameObject Player;

    private bool Active = true;
    private float TimeIs = 0;

    private string Effect;

    public float Damage = 10;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Effect = Player.GetComponent<SpellsManager>().MeteorEffect;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Active)
        {
            if (collision.GetComponent<ZombieScript>())
            {
                collision.GetComponent<HealthManager>().TakeDamage(Damage);
                collision.GetComponent<EffectManager>().ApplyEffect(Effect);
            }
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
            if (TimeIs > 0.1f && Active) 
            { 
                Active = false;

                GetComponent<Animator>().SetBool("Disappear", true);
            }
            if(TimeIs > 1.2f)
            {
                Destroy(gameObject); 
            }
        }
}
