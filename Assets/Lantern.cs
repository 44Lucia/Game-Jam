using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    CircleCollider2D m_collider;
    [SerializeField] LayerMask m_enemyDetection;

    private void Awake() {
        m_collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D p_collider) {
        if(p_collider.tag == "Enemy"){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (p_collider.transform.position - transform.position).normalized, 1000, m_enemyDetection);
            if(hit.collider == null) { return;}
            if(hit.collider.gameObject.tag == "Enemy"){
                Debug.Log("Enemy detected");
            }
            else{
                Debug.Log("Enemy behind obstacle");
            }

        }
    }

}
