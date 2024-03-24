using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM GameManage = null;
    public HeroMove h = null;
    public HeroCrush c = null;

    void Start()
    {
        GM.GameManage = this;
        Debug.Assert(h != null);
        Flame.getHero(h);
        Resource1.getHero(c); 
        Resource2.getHero(c); 
        Resource3.getHero(c); 
        goldobj.getHero(c);
        BombScript.getHero(c);
        BulletScript.getHero(c);
        ShieldScript.getHero(c);
        QBehav.getHero(c);
        Blink.getHero(c);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
