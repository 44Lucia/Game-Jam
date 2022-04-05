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
    private void LateUpdate() {
        bool moveX = true;
        bool moveY = true;

        Vector3 targetX = new Vector3(PlayerManager.Instance.transform.position.x, transform.position.y, transform.position.z);
        Vector3 targetY = new Vector3(transform.position.x, PlayerManager.Instance.transform.position.y, transform.position.z);

        if(targetX.x - 1280/2 < m_leftLimit.position.x || targetX.x + 1280/2 > m_rightLimit.position.x){
            moveX = false;
            
        }
        if(targetY.y - 720/2 < m_bottomLimit.position.y || targetY.y + 720/2 > m_topLimit.position.y){
            moveY = false;
        }

        if(moveX){
            transform.position = Vector3.SmoothDamp(transform.position, targetX, ref velocityX, 1, 150, Time.deltaTime);
        }
        if(moveY){
            transform.position = Vector3.SmoothDamp(transform.position, targetY, ref velocityY, 1, 150, Time.deltaTime);
        }
        
    }
}
