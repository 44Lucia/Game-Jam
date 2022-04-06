using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static PlayerManager m_instance;

    static public PlayerManager Instance {
        get { return m_instance;}
        private set {}
    }

    #region Animation

    string m_moveLeftAnimationName      = "moveLeft";
    string m_moveRightAnimationName       = "moveRight";
    string m_moveTopAnimationName      = "moveTop";
    string m_moveBottomAnimationName     = "moveBottom";
    string m_idleBottomAnimationName      = "idleBottom";
    string m_idleLeftAnimationName = "idleLeft";
    string m_idleRigthAnimationName = "idleRight";
    string m_idleTopAnimationName = "idleTop";
    string m_executeRightAnimationName = "execute";
    string m_executeLeftAnimationName = "execute_left";
    string m_observationLeftAnimationName = "observationLeft";
    string m_observationRightAnimationName = "observationRigth";
    int[] m_animationHash = new int[(int)PLAYER_ANIMATION.LAST_NO_USE];

    PLAYER_ANIMATION m_lastPosition = 0;

    Animator m_animator;
    PLAYER_ANIMATION m_animationState;
    int m_currentAnimationHash = 0;
    bool m_canPlayerMove = true;

    Timer walkChronometer;
    Timer m_animationEventTimer;
    bool m_isAnimationEventActive = false;

    public void ChangeAnimationState(PLAYER_ANIMATION p_animationState)
    {
        int newAnimationHash = m_animationHash[(int)p_animationState];

        if (m_currentAnimationHash == newAnimationHash) return;   // stop the same animation from interrupting itself
        m_animator.Play(newAnimationHash);                // play the animation
        m_currentAnimationHash = newAnimationHash;                // reassigning the new state
        m_animationState = p_animationState;
    }

    #endregion 

    Rigidbody2D rb2D;
    [SerializeField] float speed;

    private Vector2 moveInput;

    private void Awake() {

        if(m_instance == null){ m_instance = this;}
        else { Destroy(this.gameObject);}
        rb2D = GetComponent<Rigidbody2D>();
        walkChronometer = gameObject.AddComponent<Timer>();
        m_animator = GetComponent<Animator>();
        m_animationEventTimer = gameObject.AddComponent<Timer>();

    }
    void Start()
    {
        m_animationEventTimer.Duration = 1.0f;
        rb2D.rotation = 0;
        m_animationHash[(int)PLAYER_ANIMATION.IDLEBOTTOM]                  = Animator.StringToHash(m_idleBottomAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.IDLERIGTH]                   = Animator.StringToHash(m_idleRigthAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.IDLELEFT]                   = Animator.StringToHash(m_idleLeftAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.IDLETOP] = Animator.StringToHash(m_idleTopAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.MOVE_LEFT]                 = Animator.StringToHash(m_moveLeftAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.MOVE_RIGHT]                = Animator.StringToHash(m_moveRightAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.MOVE_TOP]                 = Animator.StringToHash(m_moveTopAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.MOVE_BOTTOM]                 = Animator.StringToHash(m_moveBottomAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.OBSERVATION_RIGHT]                 = Animator.StringToHash(m_observationRightAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.EXECUTE_LEFT]                 = Animator.StringToHash(m_executeLeftAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.EXECUTE_RIGHT]                 = Animator.StringToHash(m_executeRightAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.OBSERVATION_LEFT]                 = Animator.StringToHash(m_observationLeftAnimationName);
       
        walkChronometer.Duration = SoundManager.Instance.GetAudioClipDuration(AudioClipName.PLAYER_WALK);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsPaused) { return ;}

        if(m_isAnimationEventActive && m_animationEventTimer.IsFinished){
            m_canPlayerMove = true;
            m_isAnimationEventActive = false;
            ReturnToIdle();
        }

        if(m_canPlayerMove){
            float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(moveX < 0){
            ChangeAnimationState(PLAYER_ANIMATION.MOVE_LEFT);
            m_lastPosition = PLAYER_ANIMATION.IDLELEFT;
            if (walkChronometer.IsFinished)
            {
                SoundManager.Instance.PlayOnce(AudioClipName.PLAYER_WALK);
                walkChronometer.Run();
            }
        }
        else if(moveX > 0){
            ChangeAnimationState(PLAYER_ANIMATION.MOVE_RIGHT);
            m_lastPosition = PLAYER_ANIMATION.IDLERIGTH;
            if (walkChronometer.IsFinished)
            {
                SoundManager.Instance.PlayOnce(AudioClipName.PLAYER_WALK);
                walkChronometer.Run();
            }
        }
        else if(moveY > 0){
            ChangeAnimationState(PLAYER_ANIMATION.MOVE_TOP);
            m_lastPosition = PLAYER_ANIMATION.IDLETOP;
            if (walkChronometer.IsFinished)
            {
                SoundManager.Instance.PlayOnce(AudioClipName.PLAYER_WALK);
                walkChronometer.Run();
            }
        }
        else if(moveY < 0){
            ChangeAnimationState(PLAYER_ANIMATION.MOVE_BOTTOM);
            m_lastPosition = PLAYER_ANIMATION.IDLEBOTTOM;
            if (walkChronometer.IsFinished)
            {
                SoundManager.Instance.PlayOnce(AudioClipName.PLAYER_WALK);
                walkChronometer.Run();
            }
        }
        else{
            ChangeAnimationState(m_lastPosition);
        }

        Vector2 m_direction = new Vector2(moveX, moveY);

        rb2D.velocity = m_direction * speed;
        }

    }

    public Vector2 Position{
        get { return new Vector2(transform.position.x, transform.position.y);}
    }

    public void velocityPlayer(float value) 
    { 
        speed += value; 
    }

    public void Search(Vector3 p_position){
        m_canPlayerMove = false;
        if(p_position.x > transform.position.x){
            ChangeAnimationState(PLAYER_ANIMATION.OBSERVATION_RIGHT);
            m_lastPosition = PLAYER_ANIMATION.IDLERIGTH;
        }else{
            ChangeAnimationState(PLAYER_ANIMATION.OBSERVATION_LEFT);
            m_lastPosition = PLAYER_ANIMATION.IDLELEFT;
        }
        m_animationEventTimer.Run();
        m_isAnimationEventActive = true;
    }

    public void EndEvent(){
        m_animationEventTimer.Stop();
    }

    public void Execute(Vector3 p_position){
        m_canPlayerMove = false;
        if(p_position.x > transform.position.x){
            ChangeAnimationState(PLAYER_ANIMATION.EXECUTE_RIGHT);
            m_lastPosition = PLAYER_ANIMATION.IDLERIGTH;
        }else{
            ChangeAnimationState(PLAYER_ANIMATION.EXECUTE_LEFT);
            m_lastPosition = PLAYER_ANIMATION.IDLELEFT;
        }
        m_animationEventTimer.Run();
        m_isAnimationEventActive = true;
    }

    public void ReturnToIdle(){
        m_canPlayerMove = true;
        ChangeAnimationState(m_lastPosition);
    }

}
