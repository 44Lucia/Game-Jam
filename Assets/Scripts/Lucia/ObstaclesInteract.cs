using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesInteract : MonoBehaviour
{
    [SerializeField] GameObject alert;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown("k"))
        {
            alert.SetActive(true);
            Debug.Log("Lo has logrado");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        alert.SetActive(false);
    }
}
