using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalesImageScript : MonoBehaviour
{
    public GameObject imagescale;
    
    private bool a;
    public int SizeToScale;
    public int SizeToDownScale;

    // Start is called before the first frame update
    private void Awake()
    {
        imagescale.GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (imagescale.transform.localScale.x >= SizeToScale)
        {
            a = true;
            
            
        }
        if (imagescale.transform.localScale.y <= -SizeToDownScale)
        {
            
            a = false;
        }
        if(a)
        {
            imagescale.transform.localScale += new Vector3(-100 * Time.deltaTime, -100 * Time.deltaTime, -100 * Time.deltaTime);
        }
        if(!a)
        {
            imagescale.transform.localScale += new Vector3(100 * Time.deltaTime, 100 * Time.deltaTime, 100 * Time.deltaTime);
        }
    }
}
