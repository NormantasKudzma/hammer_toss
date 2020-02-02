using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMoveLeftRight : MonoBehaviour
{
    public Rigidbody2D image;
    public float MoveLeftTill;
    public float MoveRightTill;
    ThrowItem itemcheck;
    // Start is called before the first frame update
    private void Awake()
    {
        image.GetComponent<Rigidbody2D>();
        itemcheck = GameObject.FindGameObjectWithTag("Player").GetComponent<ThrowItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemcheck.wark)
        {
            image.velocity = new Vector3(0, 0, 0);
            image.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (image.gameObject.transform.position.x <= MoveLeftTill)
        {
            image.velocity = new Vector3(20, 0, 0);
        }
        if (image.gameObject.transform.position.x >= MoveRightTill)
        {
            image.velocity = new Vector3(-20, 0, 0);
        }
    }
}
