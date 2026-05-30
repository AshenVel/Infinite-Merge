
using UnityEngine;

public class LaserOld : MonoBehaviour
{
    private GameObject Player;

    private float TimeIs = 0;
    private float TimeIsTwo = 0;

    private Vector2 OldScale;
    float ScaleAdd = 1f;
    private Vector3 direction;

    private void Start()
    {
        Player = GameObject.Find("Player");
        if(Player.GetComponent<SpellsManager>().Target.transform.position.x < -0.2f)
        {
            //direction = (Player.GetComponent<SpellsManager>().Target.transform.position + Player.GetComponent<SpellsManager>().PointD.transform.position);
        }
        if (Player.GetComponent<SpellsManager>().Target.transform.position.x > 0.2f)
        {
            //direction = (Player.GetComponent<SpellsManager>().Target.transform.position + Player.GetComponent<SpellsManager>().PointG.transform.position);
        }
        else if (Player.GetComponent<SpellsManager>().Target.transform.position.y < -2.5f)
        {
            //direction = (Player.GetComponent<SpellsManager>().Target.transform.position + Player.GetComponent<SpellsManager>().PointA.transform.position);
        }
        else if (Player.GetComponent<SpellsManager>().Target.transform.position.y < -2f)
        {
            //direction = (Player.GetComponent<SpellsManager>().Target.transform.position + Player.GetComponent<SpellsManager>().Point.transform.position);
        }
        else if(Player.GetComponent<SpellsManager>().Target.transform.position.y > -2f)
        {
            //direction = (Player.GetComponent<SpellsManager>().Target.transform.position + Player.GetComponent<SpellsManager>().SpawnSpell.transform.position);
        }


        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ZombieScript>())
        {
            collision.GetComponent<HealthManager>().TakeDamage(30);
            collision.GetComponent<EffectManager>().ApplyEffect(Player.GetComponent<SpellsManager>().LaserEffect);
        }
    }
    private void Update()
    {
        TimeIs += Time.deltaTime;
        TimeIsTwo += Time.deltaTime;
        if (TimeIs > 2f)
        {
            OldScale = transform.localScale;
            transform.localScale = new Vector2(OldScale.x, OldScale.y + ScaleAdd);
        }

        if(TimeIsTwo > 4f)
        {
            Destroy(gameObject);
        }
    }


}
