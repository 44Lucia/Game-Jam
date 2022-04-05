using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    public static GameManager Instance { get { return m_instance;}}
    private void Awake() {
        if(m_instance == null){ m_instance = this; }
        else { Destroy(this.gameObject); }
    }
    Obstacle m_currentObstacle;

    public void SetCurrentObstacle(Obstacle p_obstacle){
        m_currentObstacle = p_obstacle;
    }

    public Obstacle GetCurrentObstacle(){
        return m_currentObstacle;
    }

    public void HandleEvent(bool p_hasWon){
        if(!p_hasWon){
            Enemy enemy = m_currentObstacle.FreeHidingSpot();
            EnemyManager.Instance.HideEnemy(enemy);
        }
        else{
            Enemy enemy = m_currentObstacle.FreeHidingSpot();
            EnemyManager.Instance.KillEnemy(enemy);
        }
    }

}
