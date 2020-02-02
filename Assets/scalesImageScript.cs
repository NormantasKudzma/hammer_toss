using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalesImageScript : MonoBehaviour
{
    public GameObject imagescale;
    Vector3 a;

    // Start is called before the first frame update
    private void Awake()
    {
        imagescale.GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(imagescale.transform.localScale.x >= 300)
        {
            imagescale.transform.localScale -= new Vector3(100 * Time.deltaTime,100 * Time.deltaTime, 100 * Time.deltaTime);
        }
        if (imagescale.transform.localScale.x <= 300)
        {
            imagescale.transform.localScale += new Vector3(100 * Time.deltaTime, 100 * Time.deltaTime, 100 * Time.deltaTime);
            return;
        }
    }
}
