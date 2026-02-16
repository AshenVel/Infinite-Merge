using UnityEngine;
using UnityEngine.Rendering;

public class ClassiqueZombie : MonoBehaviour
{
    public float PV = 15;
    public float Defence = 1;
    public float Speed = 2;
    public float DamageVillage = 10;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<HealthManager>().PV = PV;
        GetComponent<HealthManager>().Defence = Defence;
        GetComponent<HealthManager>().DamageVillage = DamageVillage;
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x,-1*Speed);
    }

}
