using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRUEBA : MonoBehaviour
{
    private int counter = 1;
    public float fillAmount = 0;
    public float timeThreshold = 0;
    [SerializeField] PRUEBA input;
    [SerializeField] GameObject image;
    [SerializeField] GameObject killBar;
    InstaKillProof m_killBarScript;
    bool m_isActive = false;

    private void Start() {
        m_killBarScript = killBar.GetComponent<InstaKillProof>();
    }

    // Update is called once per frame
    void Update()
    {

        if(m_isActive){
            fillAmounts(0.02f);
        }
        else{
            m_isActive = false;
            if(GameManager.Instance.GetCurrentObstacle() != null){
                GameManager.Instance.GetCurrentObstacle().FinishEvent();
            }
            GameManager.Instance.CanStartInteracting = true;
            fillAmount = 0;
        }

        if (valueFillAmount() >= 1)
        {
            //image.SetActive(false);
            if (counter == 1)
            {
                m_isActive = false;
                if(GameManager.Instance.GetCurrentObstacle().IsEnemyHiding){
                    killBar.SetActive(true);
                    m_killBarScript.InitializeEvent(PlayerManager.Instance.Position);
                    GameManager.Instance.GetCurrentObstacle().FinishEvent();
                }
                else{
                    GameManager.Instance.GetCurrentObstacle().FinishEvent();
                    GameManager.Instance.CanStartInteracting = true;
                }
                counter--;
                fillAmount = 0;
                GameManager.Instance.GetCurrentObstacle().HasPressedK = false;
            }
        }

        /*timeThreshold += Time.deltaTime;

        if (timeThreshold > .05)
        {
            timeThreshold = 0;
            fillAmount -= .02f;
        }

        if (fillAmount < 0)
        {
            fillAmount = 0;
        }*/

        GetComponent<Image>().fillAmount = fillAmount;
    }

    public void fillAmounts(float value) 
    { 
         fillAmount += value; 
    }

    public void Initialize(){
        GetComponent<Image>().fillAmount = 0;
        m_isActive = true;
        counter = 1;
    }
    public float valueFillAmount() { return fillAmount; }
    public void SetInactive(){
        m_isActive = false;
        GameManager.Instance.CanStartInteracting = true;
        counter--;
        fillAmount = 0;
    }
}
