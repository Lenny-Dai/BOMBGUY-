using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    static private HeroCrush h = null;
    static public void getHero(HeroCrush g){
        h = g;
    }

    private int health;
    // private GameObject[] list;
    void Start()
    {
        // list = new GameObject[13];
        health = h.gethealth();
    }

    void Update()
    {
        
    }
}
