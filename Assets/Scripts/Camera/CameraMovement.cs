using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform m_leftLimit;
    [SerializeField] Transform m_rightLimit;
    [SerializeField] Transform m_topLimit;
    [SerializeField] Transform m_bottomLimit;
    Vector3 velocityX = Vector3.zero;
    Vector3 velocityY = Vector3.zero;
    bool moveX = true;
    bool moveY = true;
    Vector3 target;

    private void Start() {
        target = transform.position;
    }

    private void Update() {
        
        target.x = PlayerManager.Instance.transform.position.x;
        target.y = PlayerManager.Instance.transform.position.y;

        if(target.x - 1280/2 < m_leftLimit.position.x){
            target.x = m_leftLimit.position.x + 1280/2;
        }
        else if(target.x + 1280/2 > m_rightLimit.position.x){
            target.x = m_rightLimit.position.x -1280/2;
        }

        if(target.y - 720/2 < m_bottomLimit.position.y){
            target.y = m_bottomLimit.position.y + 720/2;
        }
        else if(target.y + 720/2 > m_topLimit.position.y){
            target.y = m_topLimit.position.y - 720/2;
        }

    }  

    private void LateUpdate() {

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), ref velocityX, 1f, 150);
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, target.y, transform.position.z), ref velocityY, 1f, 150);
        
    }
}
