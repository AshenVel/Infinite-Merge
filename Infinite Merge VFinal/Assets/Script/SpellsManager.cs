using UnityEngine;
using System.Collections;


public class SpellsManager : MonoBehaviour
{
    public GameObject Target;
    public GameObject SpawnSpell;
    public GameObject Meteor;
    public GameObject Ball;
    public GameObject Laser;
    public GameObject Storm;

    // public GameObject Point;
    //public GameObject PointA;
    //public GameObject PointG;
    //public GameObject PointD;

    private bool MeteorNow = false;
    public string MeteorEffect;

    private bool BallNow = false;
    public string BallEffect;

    private bool LaserNow = false;
    public string LaserEffect;

    private bool StormNow = false;
    public string StormEffect;

    public void SpellLauncher(string Type,string EffectChoose)
    {  
        if (Type == "meteor")
        {
            if (!MeteorNow)
            {
                MeteorEffect = EffectChoose;
                StartCoroutine(DoMeteor());
            }
        }
        else if(Type == "laser")
        {
            if (!LaserNow)
            {
                LaserEffect = EffectChoose;
                DoLaser();
            }
        }
        else if(Type == "storm")
        {
            if (!StormNow)
            {
                StormEffect = EffectChoose;
                StartCoroutine(DoStorm());
            }
        }
        else if(Type == "ball")
        {
            if (!BallNow)
            {
                BallEffect = EffectChoose;
                StartCoroutine(DoBall());
            }
        }
    }

    private IEnumerator DoMeteor()
    {
        MeteorNow = true;
        yield return new WaitForSeconds(2f);
        Instantiate(Meteor, Target.transform.position, Meteor.transform.rotation);
        MeteorNow = false;
    }
    private IEnumerator DoBall()
    {
        BallNow = true;
        yield return new WaitForSeconds(0.5f);
        Instantiate(Ball, SpawnSpell.transform.position, Ball.transform.rotation);
        BallNow = false;
    }
    private void DoLaser()
    {
        LaserNow = true;
        Instantiate(Laser, Target.transform.position, Laser.transform.rotation);
        LaserNow = false;
    }
    private IEnumerator DoStorm()
    {
        StormNow = true;
        yield return new WaitForSeconds(2f);
        Instantiate(Storm, Target.transform.position, Storm.transform.rotation);
        StormNow = false;
    }



}
