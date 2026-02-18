using Mono.Cecil;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private GameObject Player;

    private bool Active = true;
    private float TimeIs = 0;

    public float Damage = 10;

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
                collision.GetComponent<HealthManager>().TakeDamage(Damage);
                collision.GetComponent<EffectManager>().ApplyEffect(Player.GetComponent<SpellsManager>().MeteorEffect);
            }
        }
    }
        private void Update() 
        { 
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
