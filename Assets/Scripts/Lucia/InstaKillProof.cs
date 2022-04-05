using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKillProof : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] GameObject bar;
    [SerializeField] GameObject target;
    [SerializeField] GameObject slider;

    public bool facingRigth;
    int maxLaps = 1;
    int lap = 0;
    float m_direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        facingRigth = true;
        InitializeEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (lap <= maxLaps)
        {
            slider.transform.position += new Vector3(m_direction * moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BarrierInstaKill" && lap == 0)
        {
            facingRigth = false;
            lap++;
            m_direction = -1;
        }
        if (collision.gameObject.tag == "BarrierInstaKill" && facingRigth)
        {
            bar.SetActive(false);
            GameManager.Instance.HandleEvent(false);
            //pierdes
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        facingRigth = true;
    }

    private void InitializeEvent() 
    {
        Vector3 position = new Vector3(Random.Range(63.2f, 152), -115.7f, 0);
        target.transform.position = position;
        slider.transform.position = new Vector3(63.2f, -115.58f, 0);
        lap = 0;
        m_direction = 1;
    }
}
