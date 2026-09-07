using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //public float CoefDefence;

    public void TakeDamage(float damage)
    {
        //CoefDefence = ((100f - GetComponent<ZombieScript>().Defence) / 100f);
        GetComponent<ZombieScript>().PV -= damage;
        GetComponent<Animator>().SetTrigger("DamageEnemy");
        if (GetComponent<ZombieScript>().PV <= 0) { Destroy(gameObject); }
    }
}
