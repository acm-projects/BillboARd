using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectPlacement : MonoBehaviour
{
    public GameObject m_PlaneParent;

    public void ActivatePlaneDetection()
    {
        m_PlaneParent.SetActive(true);
    }

    public void DeactivatePlaneDetection()
    {
        m_PlaneParent.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_PlaneParent.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
