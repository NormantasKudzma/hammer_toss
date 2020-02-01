using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrowItem : MonoBehaviour
{
    enum State
    {
        STATE_IDLE,
        STATE_THROWING,
    }

    public Rigidbody2D throwitem;
    public bool wark;
    public float strenght = 45;

   /* public bool up;
    public bool down;*/


    public bool enablerotate;

    public float m_IdleRotationSpeed = 90.0f;
    public float m_IdleMinAngle = -33.0f;
    public float m_IdleMaxAngle = 50.0f;
    public float m_IdleRotDist = 0.17f;
    private State m_State;
    private Vector3 m_StartingPos;
    private float m_IdleAngle = 0.0f;
    public GameObject m_PivotObject;
  
    int a = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        throwitem.GetComponent<Rigidbody2D>();
        throwitem.constraints = RigidbodyConstraints2D.FreezePositionY;

        m_State = State.STATE_IDLE;
        m_StartingPos = transform.position;
    }
    
    void throwObject()
    {
        throwitem.constraints = RigidbodyConstraints2D.None;

        var throwAngle = m_IdleAngle - 50.0f;
        throwitem.velocity = new Vector3(-strenght * Mathf.Sin(Mathf.Deg2Rad * throwAngle), strenght * Mathf.Cos(Mathf.Deg2Rad * throwAngle) * 1.5f, 0);

        throwitem.gravityScale = 6.5f;
        enablerotate = true;
        m_State = State.STATE_THROWING;

        var splitHandScript = GetComponent<SplitHand>();
        if (splitHandScript != null)
        {
            splitHandScript.ThrowItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ObjectToSmash")
        { 
            throwitem.velocity = new Vector3(-35, 40, 0);
            wark = true;
            enablerotate = false;
        }
        if(collision.gameObject.tag == "BottomRespawn" && !wark)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_State == State.STATE_IDLE)
        {
            m_IdleAngle += Time.deltaTime * m_IdleRotationSpeed;
            if (m_IdleAngle <= m_IdleMinAngle || m_IdleAngle >= m_IdleMaxAngle)
            {
                m_IdleAngle = Mathf.Clamp(m_IdleAngle, m_IdleMinAngle + 0.5f, m_IdleMaxAngle - 0.5f);
                m_IdleRotationSpeed = -m_IdleRotationSpeed;
            }

            var angle = transform.localEulerAngles;
            angle.z = m_IdleAngle;
            transform.localEulerAngles = angle;

            var pivot = m_StartingPos - m_PivotObject.transform.localPosition;
            pivot = Quaternion.Euler(0.0f, 0.0f, 250 + m_IdleAngle) * pivot * m_IdleRotDist;
            transform.position = m_StartingPos + pivot;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && a == 0)
        {
            a = 1;
            throwObject();
        }
        if(wark)
        {
            throwitem.transform.Rotate(0, 0, 360 * Time.deltaTime);
        }
        if(enablerotate)
        {
            throwitem.transform.Rotate(0, 0, -360 * Time.deltaTime);
        }
        if (!wark && a==1)
        {
            throwitem.constraints = RigidbodyConstraints2D.None;
           // throwitem.transform.Rotate(0, 0, -360 * Time.deltaTime);
        }
    }
}
