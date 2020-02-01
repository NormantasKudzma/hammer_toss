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
    public float strenght = 200;

   /* public bool up;
    public bool down;*/


    public bool enablerotate;

    public float m_IdleRotationSpeed = 90.0f;
    public float m_IdleMinAngle = -90.0f;
    public float m_IdleMaxAngle = 0.0f;
    public float m_IdleRotDist = 4.0f;
    private State m_State;
    private Vector3 m_StartingPos;
    private float m_IdleAngle = 0.0f;
  
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
        Debug.Log("Throw angle " + m_IdleAngle);

        throwitem.constraints = RigidbodyConstraints2D.None;
        throwitem.velocity = new Vector3(-strenght * Mathf.Sin(Mathf.Deg2Rad * m_IdleAngle), strenght * Mathf.Cos(Mathf.Deg2Rad * m_IdleAngle) * 1.5f, 0);
        Debug.Log("vector " + throwitem.velocity.ToString());

        throwitem.gravityScale = 6.5f;
        enablerotate = true;
        m_State = State.STATE_THROWING;
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
       /* if(collision.gameObject.tag == "LeftRespawn")
        {
            SceneManager.LoadScene("Level2");
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if (m_State == State.STATE_IDLE)
        {
            m_IdleAngle -= Time.deltaTime * m_IdleRotationSpeed;
            if (m_IdleAngle <= m_IdleMinAngle || m_IdleAngle >= m_IdleMaxAngle)
            {
                m_IdleAngle = Mathf.Clamp(m_IdleAngle, m_IdleMinAngle + 0.5f, m_IdleMaxAngle - 0.5f);
                m_IdleRotationSpeed = -m_IdleRotationSpeed;
            }

            var angle = transform.localEulerAngles;
            angle.z = m_IdleAngle;
            transform.localEulerAngles = angle;

            var pos = transform.position;
            pos.x = m_StartingPos.x - Mathf.Sin(Mathf.Deg2Rad * m_IdleAngle) * m_IdleRotDist;
            pos.y = m_StartingPos.y + Mathf.Cos(Mathf.Deg2Rad * m_IdleAngle) * m_IdleRotDist;
            transform.position = pos;
        }


      /*  if(throwitem.position.y <= 6)
        {
            strenght = 10;
        }
       
        if(throwitem.position.y >= 10)
        {
            strenght = 30 ;
        }*/

        // Vietoje rotationas kol nera user input'o
       /* if (throwitem.position.y <= 5.6295f && a == 0)
        {
            
            throwitem.velocity = new Vector3(0, 10, 0);

          throwitem.constraints = RigidbodyConstraints2D.None;
           
        }

        if (throwitem.position.y >= 10.5295f && a == 0)
        {
            throwitem.velocity = new Vector3(0, -10, 0);
            

        }*/
      
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
