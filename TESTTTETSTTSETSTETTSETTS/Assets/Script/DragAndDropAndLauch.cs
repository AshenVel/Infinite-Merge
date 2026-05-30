
using UnityEngine;
using UnityEngine.Rendering;


public class DragAndDropAndLauch : MonoBehaviour
{
    private Vector3 MousePositionOnObject;

    public string Element;
    public string Type;

    private GameObject SpellsManager;

    private GameObject SpellAccessManager;

    private GameObject target;

    private void Start()
    {
        target = GameObject.Find("Target");

        SpellsManager = GameObject.Find("Player");

        SpellAccessManager = GameObject.Find("SpellAccessManager");
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void OnMouseDown()
    {
        MousePositionOnObject = gameObject.transform.position - GetMouseWorldPosition();
        if (Type == "meteor") { target.transform.localScale = new Vector3(1.5f, 1.5f, 0); }
        if (Type == "ball") { target.transform.localScale = new Vector3(1.5f, 1.5f, 0); }
        if (Type == "storm") { target.transform.localScale = new Vector3(2.8f, 2.8f, 0); }
        if (Type == "laser") { target.transform.localScale = new Vector3(0.5f, 0.5f, 0); }
    }

    private void OnMouseDrag()
    {
        target.GetComponent<SpriteRenderer>().enabled = true;
        transform.position = GetMouseWorldPosition() + MousePositionOnObject;
        target.transform.position = transform.position;
    }

    private void OnMouseUp() 
    {
        if(transform.position.y > -2.75f)
        {
            target.GetComponent<SpriteRenderer>().enabled = false;
            SpellsManager.GetComponent<SpellsManager>().SpellLauncher(Type, Element, transform.position);
            SpellAccessManager.GetComponent<SpellAccessManager>().ClearSpells();
        }
    }
}
