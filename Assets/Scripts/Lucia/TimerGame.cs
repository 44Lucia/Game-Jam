using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerGame : MonoBehaviour
{
    public float timeToLose;

    // Start is called before the first frame update
    void Start()
    {
        timeToLose = 240;
    }

    // Update is called once per frame
    void Update()
    {
        timeToLose -= Time.deltaTime;

        Debug.Log(timeToLose);

        if (timeToLose <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
