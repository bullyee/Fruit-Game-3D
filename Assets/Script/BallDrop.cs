using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDrop : MonoBehaviour
{
    //set when dev
    [SerializeField] GameObject ballgenerator;
    [SerializeField] GameObject indicator; // a pole indicator 
    //init when start
    MeshRenderer indicator_mesh;
    BallGenerator bg;
    //set in runtime by ballgenerator
    public GameObject current = null;
    // Start is called before the first frame update
    void Start()
    {
        indicator_mesh = indicator.GetComponent<MeshRenderer>();
        bg = ballgenerator.GetComponent<BallGenerator>();
        bg.GenerateBall(transform); //first ball
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bg.DropBall(transform);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ToggleIndicator();
        }
    }
    
    //show or hide indicator
    void ToggleIndicator()
    {
        if (indicator_mesh.enabled) indicator_mesh.enabled = false;
        else indicator_mesh.enabled = true;
    }
}
