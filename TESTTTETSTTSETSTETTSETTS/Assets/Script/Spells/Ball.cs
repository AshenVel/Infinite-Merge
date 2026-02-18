using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameObject Player;

    public GameObject BallExplosion;

    private Rigidbody2D rb;

    private float x;
    private float y;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        x = Player.GetComponent<SpellsManager>().Target.transform.position.x - Player.GetComponent<SpellsManager>().SpawnSpell.transform.position.x;
        y = Player.GetComponent<SpellsManager>().Target.transform.position.y - Player.GetComponent<SpellsManager>().SpawnSpell.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 6)
        {
            Instantiate(BallExplosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        rb.linearVelocity = new Vector2(5*x,5*y);
    }
}
