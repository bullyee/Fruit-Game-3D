using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class B4CollisionDetecter: MonoBehaviour
{
    //�p�����Ʀr���
    public GameObject catchboard;
    scorecounter sc;
    //
    public GameObject ballgenerator;
    public GameObject owner;
    [SerializeField] BallGenerator bg;
    [SerializeField] GameObject ball5;
    public bool collision_occured = false;
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
            if (collision.transform.name.Contains("ball4"))
            {
                Vector3 pos = collision.transform.position;
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                gameObject.GetComponent<Collider>().enabled = false;
                GameObject c = Instantiate(ball5, (pos + transform.position) / 2, ball5.transform.rotation);
                SE.PlayPop();
                c.transform.parent = bg.transform;
                B5CollisionDetecter b = c.GetComponent<B5CollisionDetecter>();
                b.ballgenerator = ballgenerator;
                b.owner = owner;
                gameObject.SetActive(false);
                Destroy(gameObject);
                sc.scoreadd(4);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }
}
