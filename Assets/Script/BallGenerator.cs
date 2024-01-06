using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> balls = new List<GameObject>();
    //查看下顆球(測試版本，等之後用模型的預覽圖)
    [SerializeField] GameObject next_ball;
    public Sprite[] images;
    Image next_image;
    //分別把現在的球和下一顆球傳給玩家跟預覽圖
    int next_index=0;
    // Start is called before the first frame update
    void Start()
    {
        next_image=next_ball.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //generates a ball on player's hand (with disables physics and collider)
    public void GenerateBall(Transform t)
    {
        System.Random rand = new System.Random();
        //int b = rand.Next(balls.Count);
        //更換預覽圖
        int b= next_index;
        next_index=rand.Next(balls.Count);
        next_image.sprite = images[next_index];
        //
        GameObject c = Instantiate(balls[b], t.position, balls[b].transform.rotation);
        Collider collider = c.GetComponent<Collider>();
        collider.enabled = false;
        c.transform.parent = t;
        if (b == 0)
        {
            B1CollisionDetecter cdt = c.GetComponent<B1CollisionDetecter>();
            cdt.owner = t.gameObject;
            cdt.ballgenerator = transform.gameObject;
        }
        else if (b == 1)
        {
            B2CollisionDetecter cdt = c.GetComponent<B2CollisionDetecter>();
            cdt.owner = t.gameObject;
            cdt.ballgenerator = transform.gameObject;
        }
        else if (b == 2)
        {
            B3CollisionDetecter cdt = c.GetComponent<B3CollisionDetecter>();
            cdt.owner = t.gameObject;
            cdt.ballgenerator = transform.gameObject;
        }
        else
        {
            B4CollisionDetecter cdt = c.GetComponent<B4CollisionDetecter>();
            cdt.owner = t.gameObject;
            cdt.ballgenerator = transform.gameObject;
        }
        Rigidbody rg = c.GetComponent<Rigidbody>();
        rg.useGravity = false;
        rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        t.transform.GetComponent<BallDrop>().current = c;
    }

    // drop a ball (activate plysics and collider)
    public void DropBall(Transform t)
    {
        BallDrop fd = t.GetComponent<BallDrop>();
        if (fd.current == null) return;
        fd.current.transform.parent = transform;
        Collider cld = fd.current.GetComponent<Collider>();
        cld.enabled = true;
        Rigidbody rg = fd.current.GetComponent<Rigidbody>();
        rg.useGravity = true;
        rg.constraints = RigidbodyConstraints.None;
        fd.current = null;
    }
}
