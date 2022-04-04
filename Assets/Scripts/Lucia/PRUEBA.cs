using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRUEBA : MonoBehaviour
{

    public float fillAmount = 0;
    public float timeThreshold = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeThreshold += Time.deltaTime;

        if (timeThreshold > .05)
        {
            timeThreshold = 0;
            fillAmount -= .03f;
        }

        if (fillAmount < 0)
        {
            fillAmount = 0;
        }

        GetComponent<Image>().fillAmount = fillAmount;
    }

    public void fillAmounts(float value) 
    { 
         fillAmount += value; 
    }

    public float valueFillAmount() { return fillAmount; }
}
