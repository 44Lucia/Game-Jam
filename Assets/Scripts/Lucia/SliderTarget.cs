using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTarget : MonoBehaviour
{

    bool m_check = false;
    [SerializeField] GameObject bar;
    private bool youWin = false;
    bool m_isSliderInTarget = false;
    void Update()
    {

        if(m_isSliderInTarget){
            if (Input.GetKeyDown("k") && !m_check)
            {
                youWin = true;
                m_check = true;
            }
        }
        else{
            if(Input.GetKeyDown("k") && !m_check){
            youWin = false;
            m_check = true;
            }
        }
        
        if(m_check){
            if (!youWin)
            {
                Debug.Log("pierdes");
                GameManager.Instance.HandleEvent(false);
            }
            else{
                //ganas
            GameManager.Instance.HandleEvent(true);
            }
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<InstaKillProof>().IsActive = false;
            bar.SetActive(false);
            m_check = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Finish"){
            m_isSliderInTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Finish"){
            m_isSliderInTarget = false;
        }
    }
}
