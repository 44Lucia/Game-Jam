using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesInteract : MonoBehaviour
{
    [SerializeField] PRUEBA input;
    [SerializeField] GameObject image;
    [SerializeField] GameObject killBar;

    private int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (input.valueFillAmount() >= 1)
        {
            Debug.Log("Patata");
            image.SetActive(false);
            if (counter == 1)
            {
                killBar.SetActive(true);
                counter--;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey("k"))
        {
            input.fillAmounts(+.02f);
            Debug.Log("Lo has logrado");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void QuickTimeEvent() 
    {
    
    }
}
