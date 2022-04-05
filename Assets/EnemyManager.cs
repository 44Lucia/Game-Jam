using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    Obstacle[] m_obstaclesScript;
    Enemy[] m_enemiesScript;
    static EnemyManager m_instance;
    public static EnemyManager Instance { get { return m_instance;}}
    private void Awake() {

        if(m_instance == null){ m_instance = this; }
        else { Destroy(this.gameObject); }

        GameObject[] m_obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        m_obstaclesScript = new Obstacle[m_obstacles.Length];
        for(int i = 0; i < m_obstacles.Length; i++){
            m_obstaclesScript[i] = m_obstacles[i].GetComponent<Obstacle>();
        }

        GameObject[] m_enemies = GameObject.FindGameObjectsWithTag("Enemy");
        m_enemiesScript = new Enemy[m_enemies.Length];
        for(int i = 0; i < m_enemies.Length; i++){
            m_enemiesScript[i] = m_enemies[i].GetComponent<Enemy>();
            m_enemies[i].GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    public void HideEnemy(Enemy p_enemy){
        List<Obstacle> availableHidingSpots = new List<Obstacle>();
        for(int i = 0; i < m_obstaclesScript.Length; i++){
            if(!m_obstaclesScript[i].IsEnemyHiding){
                availableHidingSpots.Add(m_obstaclesScript[i]);
            }
        }
        int index = (int)Random.Range(0,availableHidingSpots.Count - 1);
        Debug.Log(index);
        availableHidingSpots[index].HideEnemy(p_enemy);
    }

}
