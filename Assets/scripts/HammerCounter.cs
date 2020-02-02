using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCounter : MonoBehaviour
{
    public int InitialCount = 3;
    public GameObject[] Hammers;

    static public int CurrentCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        //CurrentCount = InitialCount;
        for (int i = 0; i < Hammers.Length; ++i)
        {
            if (i < CurrentCount)
            {
                Hammers[i].SetActive(true);
            }
            else
            {
                Hammers[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseOne()
    {
        if (CurrentCount > 0 && CurrentCount <= Hammers.Length)
        {
            Hammers[CurrentCount - 1].SetActive(false);
        }
        CurrentCount--;

    }
}
