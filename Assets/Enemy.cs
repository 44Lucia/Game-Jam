using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Obstacle m_obstacle;

    private void Start() {
        HideEnemy(m_obstacle);
        m_obstacle.HideEnemy(this);
        
    }

    public void HideEnemy(Obstacle p_obstacle){
        transform.position = p_obstacle.HidingPosition;
    }

    

}
