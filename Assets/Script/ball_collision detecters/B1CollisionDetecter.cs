using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class B1CollisionDetecter : MonoBehaviour
{
    //計分版數字更改
    public GameObject catchboard;
    scorecounter sc;
    //Auto Completed when generated
    public GameObject ballgenerator;
    public GameObject owner;
    //使用者設定
    [SerializeField] GameObject ball2;
    //set when Start()
    BallGenerator bg;
    public bool collision_occured = false;
    PopSoundEffect SE;
    void Start()
    {
        bg = ballgenerator.GetComponent<BallGenerator>();
        SE = ballgenerator.GetComponent<PopSoundEffect>();
        catchboard = GameObject.Find("scoreboard");
        sc = catchboard.GetComponent<scorecounter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check collision with another ball or plane
        if ((collision.transform.name.Contains("Plane") || collision.transform.name.Contains("ball")))
        {
            //generate next ball if first collision
            if (!collision_occured)
            {
                bg.GenerateBall(owner.transform);
                collision_occured = true;
                EndGameDetection edg = GetComponent<EndGameDetection>();
                edg.enabled = true;
            }
            //prevent one collision code from activating twice
            if(!collision.gameObject.activeSelf || !gameObject.activeSelf) return;
            if (collision.transform.name.Contains("ball1"))
            {
                Vector3 pos = collision.transform.position; //recored position for further use
                //destroy the other game object
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                //instantiate the next lvl ball
                gameObject.GetComponent<Collider>().enabled = false;
                GameObject c = Instantiate(ball2, (pos + transform.position) / 2, ball2.transform.rotation);
                SE.PlayPop();//play pop SE
                c.transform.parent = bg.transform;
                B2CollisionDetecter b = c.GetComponent<B2CollisionDetecter>();
                b.collision_occured = true;
                b.ballgenerator = ballgenerator;
                b.owner = owner;
                EndGameDetection edg = c.GetComponent<EndGameDetection>();
                edg.enabled = true;
                //destroy self
                gameObject.SetActive(false);
                Destroy(gameObject);
                sc.scoreadd(1);//紅球加一分
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}