using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    SpriteRenderer m_renderer;

    private void Awake() {
        m_renderer = GetComponent<SpriteRenderer>();
    }

    public void SortObject(){
        if(PlayerManager.Instance.Position.y < transform.position.y){
            m_renderer.sortingOrder = 0;
        }
        else{
            m_renderer.sortingOrder = 2;
        }
    }

}
