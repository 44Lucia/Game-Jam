using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{   
    static int IDcount = 0;
    PRUEBA m_prueba;
    [SerializeField] Transform m_hidingPosition;
    SpriteRenderer m_renderer;
    bool m_isEnemyHiding = false;
    Enemy m_enemyHiding = null;
    bool m_hasPressedK = false;
    bool isEventActive = false;
    int m_ID = 0;
    Timer inspectChronometer;
    bool m_isInteractive = false;
    Text m_popUpText;

    private void Awake() {
        m_renderer = GetComponent<SpriteRenderer>();
        m_prueba = GameObject.FindGameObjectWithTag("PRUEBA").GetComponent<PRUEBA>();
        inspectChronometer = gameObject.AddComponent<Timer>();
        m_ID = IDcount++;
        m_popUpText = GameObject.FindWithTag("InteractMessage").GetComponent<Text>();
    }

    private void Start()
    {
        inspectChronometer.Duration = SoundManager.Instance.GetAudioClipDuration(AudioClipName.PLAYER_WALK);
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

    public Enemy GetCurrentEnemy(){
        return m_enemyHiding;
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

    public int ID { get { return m_ID;}}

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && Input.GetKeyUp("k"))
        {
            FinishEvent();
        }
        if(m_hasPressedK){ return ;}
        if (collision.gameObject.tag == "Player" && Input.GetKey("k"))
        {
            isEventActive = true;
            GameManager.Instance.SetCurrentObstacle(gameObject.GetComponent<Obstacle>());
            m_prueba.Initialize();
            m_hasPressedK = true;
            if (inspectChronometer.IsFinished)
            {
                SoundManager.Instance.PlayOnce(AudioClipName.INSPECTION);
                inspectChronometer.Run();
            }
        }
    }

public void FinishEvent(){
    m_hasPressedK = false;
        m_prueba.SetInactive();
        if (inspectChronometer.IsFinished)
        {
            SoundManager.Instance.PlayOnce(AudioClipName.INSPECTION);
            inspectChronometer.Run();
        }
}

    private void OnTriggerEnter2D(Collider2D p_collider) {
        if(p_collider.tag == "Player"){
            m_isInteractive = true;
            m_popUpText.rectTransform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 40,transform.position.z));
            m_popUpText.gameObject.SetActive(true);
            Debug.Log("PLAYER INSIDE");
        }
    }

    private void OnTriggerExit2D(Collider2D p_collider) {
        if(p_collider.tag == "Player"){
            m_isInteractive = false;
            m_popUpText.gameObject.SetActive(false);
            Debug.Log("PLAYER OUTSIDE");
        }
    }

}
