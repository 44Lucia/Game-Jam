using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKillProof : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] GameObject bar;
    [SerializeField] GameObject target;
    [SerializeField] GameObject slider;
    [SerializeField] float m_size = 100.0f;
    bool m_isActive = false;

    public bool facingRigth;
    int maxLaps = 1;
    int lap = 0;
    float m_direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        facingRigth = true;
        //InitializeEvent();
        this.gameObject.SetActive(false);
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
            this.gameObject.SetActive(false);
            GameManager.Instance.HandleEvent(false);
            //pierdes
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        facingRigth = true;
    }

    public void InitializeEvent(Vector3 p_position) 
    {
        float initialPosition = m_size * Random.Range(-0.5f, 0.5f);
        transform.position = p_position;
        target.transform.position = new Vector3(transform.position.x + initialPosition,transform.position.y, transform.position.z);
        //slider.transform.position = p_position;
        
        lap = 0;
        m_direction = 1;
        m_isActive = true;
    }
    public bool IsActive { get { return m_isActive;}
        set { m_isActive = value;}
    }

}
