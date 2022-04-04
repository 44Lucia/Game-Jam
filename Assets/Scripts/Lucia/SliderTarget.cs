using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTarget : MonoBehaviour
{

    [SerializeField] GameObject bar;

    private bool youWin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!youWin && Input.GetKey("l"))
        {
            Debug.Log("cagaste");
            bar.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" && Input.GetKey("l"))
        {
            youWin = true;
            bar.SetActive(false);
        }
    }
}
