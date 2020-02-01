using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrowItem : MonoBehaviour
{
    public Rigidbody2D throwitem;
    public bool wark;
    // Start is called before the first frame update
    private void Awake()
    {
        throwitem.GetComponent<Rigidbody2D>();
        throwitem.constraints = RigidbodyConstraints2D.FreezePositionY;

    }


    void throwObject()
    {
        throwitem.constraints = RigidbodyConstraints2D.None;
        throwitem.velocity = new Vector3(35,35,0);
        throwitem.gravityScale = 6.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ObjectToSmash")
        { 
            throwitem.velocity = new Vector3(-35, 40, 0);
            wark = true;
        }
        if(collision.gameObject.tag == "BottomRespawn" && !wark)
        {
            SceneManager.LoadScene("HammerTimeBois");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            throwObject();
        }
        if(wark)
        {
            throwitem.transform.Rotate(0, 0, 360 * Time.deltaTime);
        }
        if (!wark && Input.GetKey(KeyCode.Mouse0))
        {
            throwitem.transform.Rotate(0, 0, -360 * Time.deltaTime);
        }
    }
}
