using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDetector : MonoBehaviour
{
    public GameObject getUI;
    endgame end;
    // Start is called before the first frame update
    void Start()
    {
        end=gameObject.GetComponent<endgame>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)&&end.isend)
        {
            if (getUI.activeInHierarchy)
            {
                getUI.SetActive(false);
            }
            else if (!getUI.activeInHierarchy)
            {
                getUI.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.M)&&end.isend)
        {
            Physics.simulationMode = SimulationMode.Update;
            Scene scene = SceneManager.GetActiveScene();
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R) && end.isend)
        {
            Physics.simulationMode = SimulationMode.Update;
            Scene scene = SceneManager.GetActiveScene();
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

    }
}
