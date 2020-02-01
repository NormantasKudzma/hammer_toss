using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrowItem : MonoBehaviour
{
    public Rigidbody2D throwitem;
    public bool wark;
    public float strenght;

   /* public bool up;
    public bool down;*/


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
        throwitem.velocity = new Vector3(strenght,40,0);
        throwitem.gravityScale = 6.5f;
        enablerotate = true;
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
      
        if(throwitem.position.y <= 6)
        {
            strenght = 10;
        }
       
        if(throwitem.position.y >= 10)
        {
            strenght = 30 ;
        }

        // Vietoje rotationas kol nera user input'o
        if (throwitem.position.y <= 5.6295f && a == 0)
        {
            
            throwitem.velocity = new Vector3(0, 10, 0);

          throwitem.constraints = RigidbodyConstraints2D.None;
           
        }

        if (throwitem.position.y >= 10.5295f && a == 0)
        {
            throwitem.velocity = new Vector3(0, -10, 0);
            

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
