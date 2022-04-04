using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerOrder : MonoBehaviour
{

    Obstacle[] m_obstacles;

    private void Awake() {

        GameObject[] m_objectsToSort = GameObject.FindGameObjectsWithTag("Obstacle");
        m_obstacles = new Obstacle[m_objectsToSort.Length];
        for(int i = 0; i < m_objectsToSort.Length; i++){
            m_obstacles[i] = m_objectsToSort[i].GetComponent<Obstacle>();
        }

    }

    private void Update() {
        for(int i = 0; i < m_obstacles.Length; i++){
            m_obstacles[i].SortObject();
        }
    }
}
