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
        if(p_collider.tag == "Enemy" && p_collider.GetComponent<Enemy>().IsAlive){
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, (p_collider.transform.position - transform.position).normalized, 1000, m_enemyDetection);

            foreach(RaycastHit2D hit in hits){
                if(hit.collider.gameObject.tag == "Finish"){
                    p_collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    return ;
                }
                if(hit.collider.gameObject.tag == "Enemy"){
                    p_collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    return ;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D p_collider)
    {
        if(p_collider.tag == "Enemy" && p_collider.GetComponent<Enemy>().IsAlive){
            p_collider.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
