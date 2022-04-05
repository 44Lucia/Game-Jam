using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTarget : MonoBehaviour
{

    bool m_check = false;
    [SerializeField] GameObject bar;
    private bool youWin = false;
    void Update()
    {
        if(m_check){
            if (!youWin)
            {
                Debug.Log("pierdes");
                bar.SetActive(false);
                GameManager.Instance.HandleEvent(false);
            }
            else{
                //ganas
            
            bar.SetActive(false);
            GameManager.Instance.HandleEvent(true);
            }
            m_check = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" && Input.GetKey("l"))
        {
            youWin = true;
            m_check = true;
        }
    }
}
