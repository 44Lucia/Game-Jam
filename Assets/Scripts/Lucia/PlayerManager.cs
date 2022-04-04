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
    string m_idleAnimationName      = "idle";
    int[] m_animationHash = new int[(int)PLAYER_ANIMATION.LAST_NO_USE];

    Animator m_animator;
    PLAYER_ANIMATION m_animationState;
    int m_currentAnimationHash = 0;
    bool m_isBeingScripted = false;

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
        m_animator = GetComponent<Animator>();

    }
    void Start()
    {
        rb2D.rotation = 0;
        m_animationHash[(int)PLAYER_ANIMATION.IDLE]                  = Animator.StringToHash(m_idleAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.MOVE_LEFT]                 = Animator.StringToHash(m_moveLeftAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.MOVE_RIGHT]                = Animator.StringToHash(m_moveRightAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.MOVE_TOP]                 = Animator.StringToHash(m_moveTopAnimationName);
        m_animationHash[(int)PLAYER_ANIMATION.MOVE_BOTTOM]                 = Animator.StringToHash(m_moveBottomAnimationName);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(moveX < 0){
            ChangeAnimationState(PLAYER_ANIMATION.MOVE_LEFT);
        }
        else if(moveX > 0){
            ChangeAnimationState(PLAYER_ANIMATION.MOVE_RIGHT);
        }
        else if(moveY > 0){
            ChangeAnimationState(PLAYER_ANIMATION.MOVE_TOP);
        }
        else if(moveY < 0){
            ChangeAnimationState(PLAYER_ANIMATION.MOVE_BOTTOM);
        }
        else{
            ChangeAnimationState(PLAYER_ANIMATION.IDLE);
        }

        Vector2 m_direction = new Vector2(moveX, moveY);

        rb2D.velocity = m_direction * speed;

    }

    public Vector2 Position{
        get { return new Vector2(transform.position.x, transform.position.y);}
    }

}
