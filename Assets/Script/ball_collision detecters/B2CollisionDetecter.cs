using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class B2CollisionDetecter : MonoBehaviour
{
    //計分版數字更改
    public GameObject catchboard;
    scorecounter sc;
    //set by ballgenerator
    public GameObject ballgenerator;
    public GameObject owner;
    //set by Dev
    [SerializeField] GameObject ball3;
    //set by other obj
    public bool collision_occured = false;
    //set by Start
    BallGenerator bg;
    PopSoundEffect SE;

    // Start is called before the first frame update
    void Start()
    {
        bg = ballgenerator.GetComponent<BallGenerator>();
        catchboard = GameObject.Find("scoreboard");
        sc = catchboard.GetComponent<scorecounter>();
        SE = ballgenerator.GetComponent<PopSoundEffect>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.name.Contains("Plane") || collision.transform.name.Contains("ball")))
        {
            if (!collision_occured)
            {
                bg.GenerateBall(owner.transform);
                collision_occured = true;
                EndGameDetection edg = GetComponent<EndGameDetection>();
                edg.enabled = true;
            }
            if (!collision.gameObject.activeSelf || !gameObject.activeSelf) return;
            if (collision.transform.name.Contains("ball2"))
            {
                Vector3 pos = collision.transform.position;
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                gameObject.GetComponent<Collider>().enabled = false;
                GameObject c = Instantiate(ball3, (pos + transform.position) / 2, ball3.transform.rotation);
                SE.PlayPop();
                c.transform.parent = bg.transform;
                B3CollisionDetecter b = c.GetComponent<B3CollisionDetecter>();
                b.collision_occured = true;
                b.ballgenerator = ballgenerator;
                b.owner = owner;
                EndGameDetection edg = c.GetComponent<EndGameDetection>();
                edg.enabled = true;
                gameObject.SetActive(false);
                Destroy(gameObject);
                sc.scoreadd(2);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}