using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class KillSpell : MonoBehaviour
{
    public List<GameObject> Spells = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DragAndDropAndLauch>())
        {
            Spells.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<DragAndDropAndLauch>())
        {
            Spells.Remove(collision.gameObject);
        }
    }

}
