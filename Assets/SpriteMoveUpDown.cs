using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpriteMoveUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D image;
    public float MoveUpTillCoordinates;
    public float DownCoordinatesTill;

    ThrowItem itemcheck;
    // Start is called before the first frame update
    private void Awake()
    {
        image.GetComponent<Rigidbody2D>();
        itemcheck =GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowItem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemcheck.wark)
        {
            image.velocity = new Vector3(0, 0, 0);
            image.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (image.gameObject.transform.position.y >= MoveUpTillCoordinates)
        {
            image.constraints = RigidbodyConstraints2D.FreezePositionX;
            image.velocity = new Vector3(0, -10, 0);
            
        }
        if (image.gameObject.transform.position.y <= DownCoordinatesTill)
        {
            image.velocity = new Vector3(0, 18, 0);
        }
        
    }
}
