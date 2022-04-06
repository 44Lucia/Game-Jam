using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIllCircle : MonoBehaviour
{
    bool m_isActive = false;
    Image m_circle;

    [SerializeField] float m_fillaAmountSpeed = 0.02f;
    [SerializeField] GameObject killBar;
    InstaKillProof m_killBarScript;

    private void Awake() {
        m_circle = GetComponent<Image>();
        m_killBarScript = killBar.GetComponent<InstaKillProof>();
    }

    private void Start() {
        m_circle.fillAmount = 0;

    }

    private void Update() {
        if(m_isActive){
            m_circle.fillAmount += m_fillaAmountSpeed * Time.deltaTime;
        }

        if(m_circle.fillAmount >= 1){
            StopFilling();

            if(GameManager.Instance.GetCurrentObstacle().IsEnemyHiding){
                killBar.SetActive(true);
                m_killBarScript.InitializeEvent(PlayerManager.Instance.Position);
            }
            else{
                GameManager.Instance.CanStartInteracting = true;
            }
            GameManager.Instance.GetCurrentObstacle().FinishEvent();
        PlayerManager.Instance.EndEvent();
        }

    }

    public void StartFilling(){
        m_isActive = true;
        PlayerManager.Instance.Search(GameManager.Instance.GetCurrentObstacle().transform.position);
    }

    public void StopFilling(){
        m_isActive = false;
        m_circle.fillAmount = 0;

    }

}
