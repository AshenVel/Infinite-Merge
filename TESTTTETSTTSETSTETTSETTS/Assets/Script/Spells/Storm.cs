using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class Storm : MonoBehaviour
{
    private GameObject Player;

    private bool Active = true;
    private float TimeIs = 0;

    private string Effect;

    public float TimeOnStage = 3f;

    private List<GameObject> Apply = new List<GameObject>();

    private void Start()
    {
            Player = GameObject.Find("Player");
        Effect = Player.GetComponent<SpellsManager>().StormEffect;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Active)
        {
            if (collision.GetComponent<ZombieScript>())
            {
                Apply.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ZombieScript>())
        {
            Apply.Remove(collision.gameObject);
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

        if (Apply.Count > 0)
        {
            foreach (GameObject Obj in Apply)
            {
                Obj.GetComponent<EffectManager>().ApplyEffect(Effect);
            }
        }


        TimeIs += Time.deltaTime;
        if (TimeIs > TimeOnStage && Active)
        {
            Active = false;

            GetComponent<Animator>().SetBool("Disappear", true);
        }
        if (TimeIs > TimeOnStage + 1.2f)
        {
            Destroy(gameObject);
        }
    }
}
