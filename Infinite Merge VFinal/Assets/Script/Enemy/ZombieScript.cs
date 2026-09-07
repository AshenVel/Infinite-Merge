using UnityEngine;
using UnityEngine.Rendering;

public class ZombieScript : MonoBehaviour
{
    public float PV = 15;
    //public float Defence = 0;
    public float Speed = 2;
    public float DamageVillage = 10;
    public float Xp = 1;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x,-1*Speed);
    }

}
