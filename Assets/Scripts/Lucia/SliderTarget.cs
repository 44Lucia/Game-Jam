using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTarget : MonoBehaviour
{

    [SerializeField] GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" && Input.GetKeyDown("l"))
        {
            bar.SetActive(false);
        }
    }
}