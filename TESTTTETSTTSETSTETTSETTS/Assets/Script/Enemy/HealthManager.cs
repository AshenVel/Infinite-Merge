using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float PV;
    public float Defence;
    public float DamageVillage;

    public void TakeDamage(float damage)
    {
        PV -= damage;
        if (PV <= 0) { Destroy(gameObject); }
    }
}
