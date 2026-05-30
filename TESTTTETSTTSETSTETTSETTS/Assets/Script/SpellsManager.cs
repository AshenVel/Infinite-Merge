using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SpellsManager : MonoBehaviour
{
    public GameObject Target;
    public GameObject SpawnSpell;

    // public GameObject Point;
    //public GameObject PointA;
    //public GameObject PointG;
    //public GameObject PointD;

    public GameObject Meteor;
    public float MeteorCooldown = 4f;
    public string MeteorEffect;
    public float IncantationTimeMeteor = 2f;

    public GameObject Ball;
    public float BallCooldown = 3f;
    public string BallEffect;
    public float IncantationTimeBall = 0.5f;

    public GameObject Laser;
    public float LaserCooldown = 5f;
    public string LaserEffect;
    public float IncantationTimeLaser = 0.1f;

    public GameObject Storm;
    public float StormCooldown = 2f;
    public string StormEffect;
    public float IncantationTimeStorm = 2f;

    public bool ready = true;

    public GameObject ImageCooldown;

    public GameObject SpellAccessManager;

    public Image VisualCoolDown;

    private float GlobalCooldown;

    private float Cool;


    private void Start()
    {
        ImageCooldown.gameObject.SetActive(false);
    }
    public void SpellLauncher(string Type,string EffectChoose,Vector3 CoTarget)
    {  

        Target.transform.position = CoTarget;
        if (ready)
        {
            if (Type == "meteor")
            {
                MeteorEffect = EffectChoose;
                StartCoroutine(DoMeteor());
            }
            else if (Type == "laser")
            {
                LaserEffect = EffectChoose;
                StartCoroutine(DoLaser());
            }
            else if (Type == "storm")
            {
                StormEffect = EffectChoose;
                StartCoroutine(DoStorm());
            }
            else if (Type == "ball")
            {
                BallEffect = EffectChoose;
                StartCoroutine(DoBall());
            }
        }
    }

    private IEnumerator DoMeteor()
    {
        StartCoroutine(CooldDown(MeteorCooldown));   
        yield return new WaitForSeconds(IncantationTimeMeteor);
        Instantiate(Meteor, Target.transform.position, Meteor.transform.rotation);
    }
    private IEnumerator DoBall()
    {
        StartCoroutine(CooldDown(BallCooldown));
        yield return new WaitForSeconds(IncantationTimeBall);
        Instantiate(Ball, SpawnSpell.transform.position, Ball.transform.rotation);
    }
    private IEnumerator DoLaser()
    {
        StartCoroutine(CooldDown(LaserCooldown));
        yield return new WaitForSeconds(IncantationTimeLaser);
        Instantiate(Laser, Target.transform.position, Laser.transform.rotation);
    }
    private IEnumerator DoStorm()
    {
        StartCoroutine(CooldDown(StormCooldown));
        yield return new WaitForSeconds(IncantationTimeStorm);
        Instantiate(Storm, Target.transform.position, Storm.transform.rotation);
    }

    private IEnumerator CooldDown(float time)
    {
        GlobalCooldown = time;
        ready = false;
        Cool = 0;
        ImageCooldown.gameObject.SetActive(true);
        VisualCoolDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        ImageCooldown.gameObject.SetActive(false);
        VisualCoolDown.gameObject.SetActive(false);
        ready = true;
        SpellAccessManager.GetComponent<SpellAccessManager>().NewSpells();
    }

    private void Update()
    {
        if (!ready)
        {
            Cool += Time.deltaTime;
            float BackUpTime = GlobalCooldown;
            VisualCoolDown.fillAmount = Cool / BackUpTime;
        }
    }

}
