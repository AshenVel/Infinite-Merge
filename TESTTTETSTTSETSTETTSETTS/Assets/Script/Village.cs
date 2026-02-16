using UnityEngine;

public class Village : MonoBehaviour
{
    public float PV = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            TakeDamage(collision.GetComponent<HealthManager>().DamageVillage);
            collision.GetComponent<HealthManager>().PV = -1;
            collision.GetComponent<HealthManager>().TakeDamage(1);
        }
    }

    private void TakeDamage(float damage)
    {
        PV -= damage;
        GetComponent<Animator>().SetTrigger("DamageVillage");
        if(PV <= 0) EndGame();
    }

    private void EndGame()
    {
        print("perdu");
    }
}
