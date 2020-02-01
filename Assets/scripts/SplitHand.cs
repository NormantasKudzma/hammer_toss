using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitHand : MonoBehaviour
{
    public GameObject m_Pivot;
    public GameObject m_StayInPlace;
    public GameObject m_GoWithHand;
    public GameObject m_DeleteThis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowItem()
    {
        if (m_StayInPlace != null)
        {
            m_StayInPlace.SetActive(true);
            m_StayInPlace.transform.SetParent(null);
        }

        if (m_GoWithHand != null)
        {
            m_GoWithHand.SetActive(true);
        }

        if (m_DeleteThis != null)
        {
            m_DeleteThis.SetActive(false);
        }
    }
}
