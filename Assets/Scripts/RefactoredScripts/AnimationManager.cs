using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ANIMATION { PLAYER_MOVE_LEFT, PLAYER_MOVE_RIGHT, PLAYER_MOVE_TOP, PLAYER_MOVE_BOTTOM, PLAYER_IDLE_LEFT, PLAYER_IDLE_RIGHT, PLAYER_IDLE_TOP, PLAYER_IDLE_BOTTOM, PLAYER_EXECUTE_LEFT, PLAYER_EXECUTE_RIGHT, PLAYER_OBSERVATION_LEFT, PLAYER_OBSERVATION_RIGHT, LAST_NO_USE}

public class AnimationManager : MonoBehaviour
{
    static AnimationManager m_instance;

    static public AnimationManager Instance {
        get { return m_instance;}
        private set {}
    }

    private void Awake() {
        if(m_instance == null){ m_instance = this;}
        else { Destroy(this.gameObject);}
    }

    string m_playerMoveLeft = "moveLeft";
    string m_playerMoveRight  = "moveRight";
    string m_playerMoveTop = "moveTop";
    string m_playerMoveBottom = "moveBottom";
    string m_playerIdleBottom = "idleBottom";
    string m_playerIdleLeft = "idleLeft";
    string m_playerIdleRight = "idleRight";
    string m_playerIdleTop = "idleTop";
    string m_playerExecuteRight = "execute";
    string m_playerExecuteLeft = "execute_left";
    string m_playerObservationLeft = "observationLeft";
    string m_playerObservationRight = "observationRigth";

    int[] m_animationHash = new int[(int)PLAYER_ANIMATION.LAST_NO_USE];

    private void Start() {
        m_animationHash[(int)ANIMATION.PLAYER_MOVE_LEFT] = Animator.StringToHash(m_playerMoveLeft);
        m_animationHash[(int)ANIMATION.PLAYER_MOVE_RIGHT] = Animator.StringToHash(m_playerMoveRight);
        m_animationHash[(int)ANIMATION.PLAYER_MOVE_TOP] = Animator.StringToHash(m_playerMoveTop);
        m_animationHash[(int)ANIMATION.PLAYER_MOVE_BOTTOM] = Animator.StringToHash(m_playerMoveBottom);
        m_animationHash[(int)ANIMATION.PLAYER_IDLE_BOTTOM] = Animator.StringToHash(m_playerIdleBottom);
        m_animationHash[(int)ANIMATION.PLAYER_IDLE_TOP] = Animator.StringToHash(m_playerIdleTop);
        m_animationHash[(int)ANIMATION.PLAYER_IDLE_RIGHT] = Animator.StringToHash(m_playerIdleRight);
        m_animationHash[(int)ANIMATION.PLAYER_IDLE_LEFT] = Animator.StringToHash(m_playerIdleLeft);
        m_animationHash[(int)ANIMATION.PLAYER_EXECUTE_LEFT] = Animator.StringToHash(m_playerExecuteLeft);
        m_animationHash[(int)ANIMATION.PLAYER_EXECUTE_RIGHT] = Animator.StringToHash(m_playerExecuteRight);
        m_animationHash[(int)ANIMATION.PLAYER_OBSERVATION_LEFT] = Animator.StringToHash(m_playerObservationLeft);
        m_animationHash[(int)ANIMATION.PLAYER_OBSERVATION_RIGHT] = Animator.StringToHash(m_playerObservationRight);
    }    

    public void PlayAnimation(AnimatedCharacter p_animatedCharacter, ANIMATION p_animation){
        int newAnimationHash = m_animationHash[(int)p_animation];
        if(p_animatedCharacter.CurrentAnimationHash == newAnimationHash) return ;
        p_animatedCharacter.Animator.Play(m_animationHash[(int)p_animation]);
    }

}
