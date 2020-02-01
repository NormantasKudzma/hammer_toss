using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrowItem : MonoBehaviour
{
    public Rigidbody2D throwitem;
    public bool wark;

    public bool enablerotate;
    int a = 0;
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
            enablerotate = false;
        }
        if(collision.gameObject.tag == "BottomRespawn" && !wark)
        {
            SceneManager.LoadScene("HammerTimeBois");
        }
       /* if(collision.gameObject.tag == "LeftRespawn")
        {
            SceneManager.LoadScene("Level2");
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if (throwitem.position.y <= 5.6295f && a == 0)
        {
            throwitem.velocity = new Vector3(0, 10, 0);
            throwitem.constraints = RigidbodyConstraints2D.FreezePositionX;
            enablerotate = true;

        }
        if (throwitem.position.y >= 10.6295f && a == 0)
        {
            throwitem.velocity = new Vector3(0, -10, 0);
            throwitem.constraints = RigidbodyConstraints2D.FreezePositionX;
            //throwitem.transform.Rotate(0, 0, -360 * Time.deltaTime);
            enablerotate = true;
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
            throwitem.transform.Rotate(0, 0, -360 * Time.deltaTime);
        }
    }
}
