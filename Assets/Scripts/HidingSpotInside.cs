using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingSpotInside : MonoBehaviour
{
    bool m_isEnemyInside = false;
    [SerializeField] float m_interactRange = 64;
    CircleCollider2D m_collider2D;
    bool m_isInteractive = false;
    [SerializeField] Text m_popUpText;

    private void Awake() {
        m_collider2D = GetComponent<CircleCollider2D>();
    }
    
    private void Start() {
        m_collider2D.radius = m_interactRange;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, m_interactRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position, new Vector3(16,16,1));
    }

    private void OnTriggerEnter2D(Collider2D p_collider) {
        if(p_collider.tag == "Player"){
            m_isInteractive = true;
            m_popUpText.rectTransform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 40,transform.position.z));
            m_popUpText.gameObject.SetActive(true);
            Debug.Log("PLAYER INSIDE");
        }
    }

    private void OnTriggerExit2D(Collider2D p_collider) {
        if(p_collider.tag == "Player"){
            m_isInteractive = true;
            m_popUpText.gameObject.SetActive(false);
            Debug.Log("PLAYER OUTSIDE");
        }
    }

}
