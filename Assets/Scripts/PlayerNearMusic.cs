using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearMusic : MonoBehaviour
{
    Timer m_beatTimer;
    float m_duration = 8;
    [SerializeField] float m_minDetectionDistance = 10000;
    [SerializeField] float m_minVolume = 0.2f;
    [SerializeField] float m_maxVolume = 0.8f;

    private void Awake() {
        m_beatTimer = gameObject.AddComponent<Timer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_beatTimer.Duration = m_duration;
        m_beatTimer.Run();
        SoundManager.Instance.SetBeatVolume(1f);
    }

    // Update is called once per frame
    void Update()
    {

        List<Enemy> enemies = EnemyManager.Instance.ReturnAliveEnemies();

        Enemy nextEnemy = new Enemy();
        for(int i = 0; i< enemies.Count; i++){
            if(enemies[i].IsAlive){
                nextEnemy = enemies[i];
                i = enemies.Count;
            }
        }

        if(nextEnemy == null){ return;}

        Vector2 distanceVector = new Vector2((PlayerManager.Instance.transform.position.x - nextEnemy.transform.position.x), (PlayerManager.Instance.transform.position.x - nextEnemy.transform.position.x));

        float distance = distanceVector.magnitude;
        float beatVolume = m_minVolume;

        if(distance < m_minDetectionDistance){
            beatVolume = m_maxVolume - (distance/m_minDetectionDistance) * (m_maxVolume - m_minVolume);
        }

        SoundManager.Instance.SetBeatVolume(beatVolume);
        Debug.Log(beatVolume);

    }
}
