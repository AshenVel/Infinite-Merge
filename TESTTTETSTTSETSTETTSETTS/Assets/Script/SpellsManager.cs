using UnityEngine;
using System.Collections;


public class SpellsManager : MonoBehaviour
{
    public GameObject Target;
    public GameObject SpawnSpell;

    // public GameObject Point;
    //public GameObject PointA;
    //public GameObject PointG;
    //public GameObject PointD;

    public GameObject Meteor;
    private bool MeteorNow = false;
    public string MeteorEffect;
    public float IncantationTimeMeteor = 2f;

    public GameObject Ball;
    private bool BallNow = false;
    public string BallEffect;
    public float IncantationTimeBall = 0.5f;

    public GameObject Laser;
    private bool LaserNow = false;
    public string LaserEffect;
    public float IncantationTimeLaser = 0f;

    public GameObject Storm;
    private bool StormNow = false;
    public string StormEffect;
    public float IncantationTimeStorm = 2f;
    public void SpellLauncher(string Type,string EffectChoose,Vector3 CoTarget)
    {  

        Target.transform.position = CoTarget;

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
        yield return new WaitForSeconds(IncantationTimeMeteor);
        Instantiate(Meteor, Target.transform.position, Meteor.transform.rotation);
        MeteorNow = false;
    }
    private IEnumerator DoBall()
    {
        BallNow = true;
        yield return new WaitForSeconds(IncantationTimeBall);
        Instantiate(Ball, SpawnSpell.transform.position, Ball.transform.rotation);
        BallNow = false;
    }
    private IEnumerator DoLaser()
    {
        LaserNow = true;
        yield return new WaitForSeconds(IncantationTimeLaser);
        Instantiate(Laser, Target.transform.position, Laser.transform.rotation);
        LaserNow = false;
    }
    private IEnumerator DoStorm()
    {
        StormNow = true;
        yield return new WaitForSeconds(IncantationTimeStorm);
        Instantiate(Storm, Target.transform.position, Storm.transform.rotation);
        StormNow = false;
    }



}
