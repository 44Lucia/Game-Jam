using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;

    [SerializeField] GameObject child1;
    [SerializeField] GameObject child2;
    [SerializeField] GameObject child3;
    [SerializeField] GameObject child4;

    private float counterChild = 1;
    bool m_canStartInteracting = true;

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
        m_canStartInteracting = true;
        if(!p_hasWon){
            Enemy enemy = m_currentObstacle.FreeHidingSpot();
            EnemyManager.Instance.HideEnemy(enemy);
        }
        else{
            Enemy enemy = m_currentObstacle.FreeHidingSpot();
            EnemyManager.Instance.KillEnemy(enemy);
            if (counterChild == 1)
            {
                child1.SetActive(true);
                counterChild++;
            }
            else if (counterChild == 2)
            {
                child2.SetActive(true);
                counterChild++;
            }
            else if (counterChild == 3)
            {
                child3.SetActive(true);
                counterChild++;
            }
            else if (counterChild == 4)
            {
                child4.SetActive(true);
                counterChild++;
            }
        }
    }

    public bool CanStartInteracting {
        get { return m_canStartInteracting;}
        set { m_canStartInteracting = value;}
    }

}
