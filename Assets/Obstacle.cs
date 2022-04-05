using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{   PRUEBA m_prueba;
    [SerializeField] Transform m_hidingPosition;
    SpriteRenderer m_renderer;
    bool m_isEnemyHiding = false;
    Enemy m_enemyHiding = null;
    bool m_hasPressedK = false;

    private void Awake() {
        m_renderer = GetComponent<SpriteRenderer>();
        m_prueba = GameObject.FindGameObjectWithTag("PRUEBA").GetComponent<PRUEBA>();
    }

    public void SortObject(){
        if(PlayerManager.Instance.Position.y < transform.position.y){
            //m_renderer.sortingOrder = 0;
            m_renderer.sortingLayerName = "UnderPlayer";
        }
        else{
            //m_renderer.sortingOrder = 2;
            m_renderer.sortingLayerName = "OverPlayer";
        }
    }

    public bool IsEnemyHiding{ 
        get { return m_isEnemyHiding;}
        set { m_isEnemyHiding = value;}
    }

    public void HideEnemy(Enemy p_enemy){
        m_isEnemyHiding = true;
        m_enemyHiding = p_enemy;
        p_enemy.HideEnemy(this);
    }

    public Enemy FreeHidingSpot(){
        m_isEnemyHiding = false;
        Enemy enemy = m_enemyHiding;
        m_enemyHiding = null;
        return enemy;
    }

    public Vector3 HidingPosition { get { return m_hidingPosition.position;}}

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && Input.GetKeyUp("k"))
        {
            m_hasPressedK = false;
            m_prueba.SetInactive();
        }
        if(m_hasPressedK){ return ;}
        if (collision.gameObject.tag == "Player" && Input.GetKey("k"))
        {
            GameManager.Instance.SetCurrentObstacle(gameObject.GetComponent<Obstacle>());
            m_prueba.Initialize();
            m_hasPressedK = true;
        }

        
    }



}
