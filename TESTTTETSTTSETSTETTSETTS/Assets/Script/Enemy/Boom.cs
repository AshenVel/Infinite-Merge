using UnityEngine;

public class Boom : MonoBehaviour
{
    private float TimeIs;

    public GameObject ZombieBoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(ZombieBoom.GetComponent<ZombieScript>().DamageVillage);
        }

        if (collision.gameObject.GetComponent<Village>())
        {
            collision.gameObject.GetComponent<Village>().TakeDamage(ZombieBoom.GetComponent<ZombieScript>().DamageVillage);
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
