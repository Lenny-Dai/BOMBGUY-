using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QBehav : MonoBehaviour
{
    static private HeroCrush h = null;
    static public void getHero(HeroCrush g){
        h = g;
    } 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!h.getobtain()){
            Destroy(transform.gameObject);
        }
    }
}
