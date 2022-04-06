using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;

    [SerializeField] GameObject pause;

    private float counterChild = 1;
    bool m_canStartInteracting = true;
    bool pauseTimer = false;

    public static GameManager Instance { get { return m_instance;}}
    private void Awake() {
        if(m_instance == null){ m_instance = this; }
        else { Destroy(this.gameObject); }
    }
    Obstacle m_currentObstacle;

    private void Update()
    {
        if(counterChild >=4){
            Debug.Log("YOU WON");
        }
        if (Input.GetKeyDown("p"))
        {
            pauseTimer = true;
            pause.SetActive(true);
        }
    }

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
            Enemy enemy = m_currentObstacle.SetUpDeadEnemy();
            EnemyManager.Instance.KillEnemy(enemy);
            counterChild++;
        }
    }

    public bool CanStartInteracting {
        get { return m_canStartInteracting;}
        set { m_canStartInteracting = value;}
    }

    public void reestartGame() 
    {
        pauseTimer = false;
        pause.SetActive(false);
    }

    public void timerPaused(bool isPaused) 
    {
        pauseTimer = isPaused;
    }

    public bool timerPause() { return pauseTimer; }

}
