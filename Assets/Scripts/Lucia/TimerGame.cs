using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerGame : MonoBehaviour
{
    public float timeToLose;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        timeToLose = 180;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.timerPause() == false)
        {
            timeToLose -= Time.deltaTime;

            text.text = "" + Mathf.Round(timeToLose);

            if (timeToLose <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
