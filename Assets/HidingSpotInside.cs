using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpotInside : MonoBehaviour
{
    bool m_isEnemyInside = false;
    [SerializeField] float m_interactRange = 64;
    CircleCollider2D m_collider2D;

    private void Awake() {
        m_collider2D = GetComponent<CircleCollider2D>();
    }
    
    private void Start() {
        m_collider2D.radius = m_interactRange;
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, m_interactRange);
    }

    private void OnTriggerStay2D(Collider2D p_collider) {
        if(p_collider.tag == "Player"){
            
        }
    }

}
