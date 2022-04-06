using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearMusic : MonoBehaviour
{
    Timer m_beatTimer;
    float m_duration = 8;
    [SerializeField] float m_minDetectionDistance = 100;

    private void Awake() {
        m_beatTimer = gameObject.AddComponent<Timer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_beatTimer.Duration = m_duration;
        m_beatTimer.Run();
        SoundManager.Instance.SetBeatVolume(1f);
        SoundManager.Instance.PlayOnce(AudioClipName.HEARTSOUND);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_beatTimer.IsFinished){
            SoundManager.Instance.PlayOnce(AudioClipName.HEARTSOUND);
        }

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

        if(distance <= m_minDetectionDistance){
            
        }

    }
}
