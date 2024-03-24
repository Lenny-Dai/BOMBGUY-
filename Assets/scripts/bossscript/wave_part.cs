using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_part : MonoBehaviour
{
    // Start is called before the first frame update
    float lastti=0f;
    float frame=0.016f;
    float deg=0;
    float degv=0;
    int timer=0;
    int framed=1;
    GameObject bullet1=null;
    void Start()
    {
        
        transform.localPosition=new Vector3(0,100,0);
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        Sprite grain=Resources.Load<Sprite>("enemy/grain1") as Sprite;
        bullet1.GetComponent<basicbullet>().chimg(grain);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-lastti>frame){
            timer++;
            framed=1;
            lastti=Time.time;
        }
        else{
            framed=0;
        }
        if(framed==1){
            degv+=0.05f;
            deg+=degv;
            
        }
        if(timer%2==0&&framed==1){
            for (int i=0;i<=8;i++){
                GameObject bul=Instantiate(bullet1);
                basicbullet basb=bul.GetComponent<basicbullet>();
                basb.chplace(transform.localPosition.x,transform.localPosition.y);
                basb.chrot(deg+i*360/8);
                basb.chdeg(deg+i*360/8);
                basb.chv(5f);
            }
        }
    }
}
