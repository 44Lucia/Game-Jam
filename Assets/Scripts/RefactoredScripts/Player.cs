using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_STATE { IDLE, MOVE, ACTION, LAST_NO_USE }

public class Player : AnimatedCharacter
{
    static Player m_instance;
    static public Player Instance { 
        get {return m_instance;}
        set { m_instance = value;}
    }

    ANIMATION m_animationToReturnWhenIdle = ANIMATION.PLAYER_IDLE_LEFT;
    PLAYER_STATE m_state = PLAYER_STATE.IDLE;

    Timer walkChronometer;
    Timer m_animationEventTimer;
    Rigidbody2D m_rb2D;
    [SerializeField] float m_speed;
    Vector2 m_direction;


    private Vector2 moveInput;


    protected override void Awake() {
        if(m_instance == null) { m_instance = this;}
        else { Destroy(this.gameObject); }

        base.Awake();
        m_rb2D = GetComponent<Rigidbody2D>();
        walkChronometer = gameObject.AddComponent<Timer>();
        m_animationEventTimer = gameObject.AddComponent<Timer>();
    }

    private void Start() {
        m_animationEventTimer.Duration = 1.0f;
        walkChronometer.Duration = SoundManager.Instance.GetAudioClipDuration(AudioClipName.PLAYER_WALK);
    }


    private void Update() {
        if(GameManager.Instance.IsPaused){ return ;}

        m_direction.x = Input.GetAxisRaw("Horizontal");
        m_direction.y = Input.GetAxisRaw("Vertical");

        switch(m_state){

            default:break;
            case PLAYER_STATE.IDLE:
                HandleIdle();
            break;
            case PLAYER_STATE.MOVE:
                HandleMove();
            break;
            case PLAYER_STATE.ACTION:
                HandleAction();
            break;
        }

    }

    void HandleIdle(){
        if(m_direction.magnitude != 0){ m_state = PLAYER_STATE.MOVE;}
    }

    void HandleMove(){
        if(m_direction.x < 0){
            AnimationManager.Instance.PlayAnimation(this,ANIMATION.PLAYER_MOVE_LEFT);
            m_animationToReturnWhenIdle = ANIMATION.PLAYER_IDLE_LEFT;
        }
        else if(m_direction.x > 0){
            AnimationManager.Instance.PlayAnimation(this,ANIMATION.PLAYER_MOVE_RIGHT);
            m_animationToReturnWhenIdle = ANIMATION.PLAYER_IDLE_RIGHT;
        }
        else if(m_direction.y > 0){
           AnimationManager.Instance.PlayAnimation(this,ANIMATION.PLAYER_MOVE_TOP);
            m_animationToReturnWhenIdle = ANIMATION.PLAYER_IDLE_TOP;
        }
        else if(m_direction.y < 0){
            AnimationManager.Instance.PlayAnimation(this,ANIMATION.PLAYER_MOVE_BOTTOM);
            m_animationToReturnWhenIdle = ANIMATION.PLAYER_IDLE_BOTTOM;
            
        }
        else{
            AnimationManager.Instance.PlayAnimation(this, m_animationToReturnWhenIdle);
        }
        m_direction.Normalize();
        m_rb2D.velocity = m_direction * m_speed;
    }

    void HandleAction(){
        if(m_animationEventTimer.IsFinished){
            m_state = PLAYER_STATE.IDLE;
            AnimationManager.Instance.PlayAnimation(this,m_animationToReturnWhenIdle);
        }
    }

    public void Search(Vector3 p_position){
        m_state = PLAYER_STATE.ACTION;
        if(p_position.x > transform.position.x){
            AnimationManager.Instance.PlayAnimation(this,ANIMATION.PLAYER_OBSERVATION_RIGHT);
            m_animationToReturnWhenIdle = ANIMATION.PLAYER_MOVE_RIGHT;
        }else{
            AnimationManager.Instance.PlayAnimation(this,ANIMATION.PLAYER_OBSERVATION_LEFT);
            m_animationToReturnWhenIdle = ANIMATION.PLAYER_MOVE_LEFT;
        }
        m_animationEventTimer.Run();
    }

    public void Execute(Vector3 p_position){
        m_state = PLAYER_STATE.ACTION;
        if(p_position.x > transform.position.x){
            AnimationManager.Instance.PlayAnimation(this,ANIMATION.PLAYER_EXECUTE_RIGHT);
            m_animationToReturnWhenIdle = ANIMATION.PLAYER_MOVE_RIGHT;
        }else{
            AnimationManager.Instance.PlayAnimation(this,ANIMATION.PLAYER_EXECUTE_LEFT);
            m_animationToReturnWhenIdle = ANIMATION.PLAYER_MOVE_LEFT;
        }
        m_animationEventTimer.Run();
    }

}
