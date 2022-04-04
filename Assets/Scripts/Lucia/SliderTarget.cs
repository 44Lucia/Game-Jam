using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTarget : MonoBehaviour
{

    [SerializeField] GameObject bar;
    private bool youWin = false;
    void Update()
    {
        if (!youWin && Input.GetKey("l"))
        {
            Debug.Log("pierdes");
            bar.SetActive(false);
            GameManager.Instance.HandleEvent(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" && Input.GetKey("l"))
        {
            //ganas
            youWin = true;
            bar.SetActive(false);
        }
    }
}
