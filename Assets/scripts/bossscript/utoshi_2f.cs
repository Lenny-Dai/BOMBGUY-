using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class utoshi_2f : MonoBehaviour
{
    // Start is called before the first frame update
    float lastti=0f;
    float frame=0.016f;
    float deg=0;
    int timer=0;
    int framed=1;
    bool flying=false;
    GameObject bullet=null;
    Sprite bm=null;
    Sprite bh=null;
    float cx=-240,cy=0,lx=735,ly=540;
    float nowx,nowy,tgtx,tgty;
    void Start()
    {
        //中心是-240,0
        //长1470，宽1080
        transform.localPosition=new Vector3(0,100,0);
        bullet=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        bh=Resources.Load<Sprite>("enemy/ball_buge_1") as Sprite;
        bm=Resources.Load<Sprite>("enemy/ball_mid_1") as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(cx>0&&cy>0&&lx>0&&ly>0&&flying){

        }
        if(Time.time-lastti>frame){
            timer++;
            framed=1;
            lastti=Time.time;
        }
        else{
            framed=0;
        }
        if(framed==1){
            if(timer%12==0){
                
            }
        }
        if(framed==1){
            if(timer%40==0){
                int ti=12;
                float sdeg=UnityEngine.Random.Range(0,360);
                for (int i=0;i<=ti;i++){
                    
                    GameObject bul=Instantiate(bullet);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chdeg(sdeg+i*360/ti);
                    basb.chrot(sdeg+i*360/ti);
                    basb.chv(2f);
                    basb.chimg(bh);
                }
            }
            if((timer+5)%10==0){
                int ti=24;
                
                for (int i=0;i<=ti;i++){
                    GameObject bul=Instantiate(bullet);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chrot(deg+i*360/ti);
                    basb.chdeg(deg+i*360/ti);
                    basb.chv(4f);
                    basb.chimg(bm);
                }
                for (int i=0;i<=ti;i++){
                    GameObject bul=Instantiate(bullet);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chrot(-(deg+i*360/ti));
                    basb.chdeg(-(deg+i*360/ti));
                    basb.chv(4f);
                    basb.chimg(bm);
                }
            }
        }
    }
}
