using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class eightway : MonoBehaviour
{
    // Start is called before the first frame update
    float lastti=0f;
    float frame=0.016f;
    float deg=0;
    float degv=1;
    int timer=0;
    int framed=1;
    GameObject bullet1=null;
    Sprite square;
    void Start()
    {
        
        transform.localPosition=new Vector3(0,100,0);
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        square=Resources.Load<Sprite>("enemy/square_dred") as Sprite;
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
            degv=(float)Math.Sin(timer*3.14f/180);
            deg=deg+degv;
            if(deg>360){
                deg-=360;
            }
            if(deg<360){
                deg+=360;
            }
        }
        if(timer%4==0&&framed==1){
            int ti=8;
            for (int i=0;i<=ti;i++){
                GameObject bul=Instantiate(bullet1);
                basicbullet basb=bul.GetComponent<basicbullet>();
                basb.chimg(square);
                basb.chplace(transform.localPosition.x,transform.localPosition.y);
                basb.chrot(deg+i*360/ti);
                basb.chdeg(deg+i*360/ti);
                basb.chv(6f);
            }
        }
        
    }
}
