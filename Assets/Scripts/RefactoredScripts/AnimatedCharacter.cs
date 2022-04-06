using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCharacter : MonoBehaviour
{
    Animator m_animator;
    int m_currentAnimationHash = 0;
    protected virtual void Awake() {
        m_animator = GetComponent<Animator>();
    }

    public Animator Animator { get { return m_animator;}}
    public int CurrentAnimationHash { 
        get { return m_currentAnimationHash;}
        set { m_currentAnimationHash = value;}
    }

}
