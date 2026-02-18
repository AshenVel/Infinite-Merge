using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDropAndLauch : MonoBehaviour
{
    private Vector3 MousePositionOnObject;

    public string Element;
    public string Type;

    public GameObject SpellsManager;

    
    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void OnMouseDown()
    {
        MousePositionOnObject = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + MousePositionOnObject;
    }

    private void OnMouseUp() 
    {
        if(transform.position.y > -2.75f)
        {
            SpellsManager.GetComponent<SpellsManager>().SpellLauncher(Type, Element, transform.position);
            Destroy(gameObject);
        }
    }


}
