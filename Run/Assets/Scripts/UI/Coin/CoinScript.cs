using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.forward = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,0,5);

        if (PlayerScript.Instance.isGetMagnet)
        {
            getMagnet();
        }
        if (gameObject.activeInHierarchy&& gameObject.transform.parent ==null)
        {
            Vector3 dir = PlayerScript.Instance.transform.position - transform.position;
            transform.position += dir.normalized * Time.deltaTime * 20;
        }
    }
    
    public void getMagnet()
    {
        if (PlayerScript.Instance.timeGetItem>=15)
        {
            PlayerScript.Instance.timeGetItem = 0;
            PlayerScript.Instance.isGetMagnet = false;
        }

        if (Vector3.Distance(PlayerScript.Instance.transform.position, transform.position) <= 8)
        {
            transform.SetParent(null);
        }
        
        
    }


    public void OnDisable()
    {
        transform.forward = new Vector3(0,1,0);
    }
}
