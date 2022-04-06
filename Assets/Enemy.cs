using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject childHud;
    [SerializeField] Obstacle m_obstacle;
    int m_lastObstacleID;

    bool m_isAlive = true;
    SpriteRenderer m_renderer;

    #region Animation
    public enum ENEMY_ANIMATION { HIDE, DEATH, LAST_NO_USE}
    string m_deathAnimationName      = "death";
    string m_hideAnimationName       = "hide";
    Animator m_animator;
    ENEMY_ANIMATION m_animationState;
    int m_currentAnimationHash = 0;
    int[] m_animationHash = new int[(int)ENEMY_ANIMATION.LAST_NO_USE];

    public void ChangeAnimationState(ENEMY_ANIMATION p_animationState)
    {
        int newAnimationHash = m_animationHash[(int)p_animationState];

        if (m_currentAnimationHash == newAnimationHash) return;   // stop the same animation from intfloa
        m_animator.Play(newAnimationHash);                // play the animation
        m_currentAnimationHash = newAnimationHash;                // reassigning the new state
        m_animationState = p_animationState;
    }
    #endregion 

    private void Awake() {
        m_animator = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        HideEnemy(m_obstacle);
        m_obstacle.HideEnemy(this);

        m_animationHash[(int)ENEMY_ANIMATION.HIDE]                  = Animator.StringToHash(m_hideAnimationName);
        m_animationHash[(int)ENEMY_ANIMATION.DEATH]                   = Animator.StringToHash(m_deathAnimationName);

    }

    public void HideEnemy(Obstacle p_obstacle){
        transform.position = p_obstacle.HidingPosition;
        m_lastObstacleID = p_obstacle.ID;
    }

    public int LastObstacleID { get { return m_lastObstacleID;}}
    public void FlipX(){
        m_renderer.flipX = !m_renderer.flipX;
    }

    public void Die(Vector3 p_position){
        if(p_position.x < transform.position.x){
            FlipX();
        }
        ChangeAnimationState(ENEMY_ANIMATION.DEATH);
        m_isAlive = false;
        m_renderer.enabled = true;
        childHud.SetActive(true);
    }

    public bool IsAlive { get { return m_isAlive;}}

}
