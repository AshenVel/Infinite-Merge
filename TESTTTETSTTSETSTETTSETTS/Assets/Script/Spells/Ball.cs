using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameObject Player;

    public GameObject BallExplosion;


    private Rigidbody2D rb;

    private float x;
    private float y;

    private string Effect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        Effect = Player.GetComponent<SpellsManager>().BallEffect;

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
        rb.linearVelocity = new Vector2(5*x,5*y);
    }
}
