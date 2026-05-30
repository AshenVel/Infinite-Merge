using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Mouse : MonoBehaviour
{
    public GameObject Point_A;
    public GameObject Point_B;

    private GameObject CurrentTarget;

    public float speed = 5f;

    void Update()
    {
        if (transform.position == Point_A.transform.position)
        {
            CurrentTarget = Point_B;
        }
        if(transform.position == Point_B.transform.position) 
        {
            CurrentTarget = Point_A;
        }
        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.transform.position, speed * Time.deltaTime);

    }

}
