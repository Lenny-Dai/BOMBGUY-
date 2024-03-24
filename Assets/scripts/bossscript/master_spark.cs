using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class master_spark : MonoBehaviour
{
    // Start is called before the first frame update
    float lastti=0f;
    float frame=0.016f;
    //float degv=0;
    float towards=-90;
    int timer=0;
    int framed=1;
    GameObject bullet1=null;
    Sprite[] star=new Sprite[10];
    Sprite cannon;
    Sprite aura;
    bool shootstar=false;
    GameObject spark=null;
    
    void Start()
    {
        
        for(int i=1;i<=8;i++){
            star[i]=Resources.Load<Sprite>("enemy/stars/star_"+i) as Sprite;
        }
        
        transform.localPosition=new Vector3(-100,200,0);
        bullet1=Resources.Load("enemy/prefab/bulletclass") as GameObject;
        cannon=Resources.Load<Sprite>("enemy/master_spark") as Sprite;
        aura=Resources.Load<Sprite>("enemy/spark_aura") as Sprite;
        spark=Instantiate(bullet1);
                    
                    SpriteRenderer s = spark.GetComponent<SpriteRenderer>();
                Color c = s.color;
                c.a=0.5f;
                s.color=c;
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
        float t1=240,t2=300,t3=360,t4=600,t5=660;
        //0-t1 240f 无事发生
        //t1-t2 60f 预警伸出
        //t2-t3 60f 魔炮变宽
        //t3-t4 240f 持续开炮，开始发星弹和冲击
        //t4-t5 60f alpha--
        //t5+ 停止发星弹，回到t=0
        if(framed==1){
            if(timer<t1){

            }
            else if(timer<t2){
                

                if(timer==t1){
                    basicbullet basb=spark.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chimg(cannon);
                    basb.chrot(towards);
                    basb.chscale(0,0);
                }
                else{
                    basicbullet basb=spark.GetComponent<basicbullet>();
                    basb.chscale(0.015f*(timer-t1)*10,0.2f);
                }
            }
            else if(timer<t3){
                shootstar=true;
                basicbullet basb=spark.GetComponent<basicbullet>();
                basb.chscale(10,0.015f*(timer-t2)*10);
            }
            else if(timer<t4){
                
            }
            else if(timer<t5){
                
            }
            else{
                shootstar=false;
                timer=0;
            }
        }
        if(shootstar&&framed==1){
            if(timer%15==0){
            int ti=12;
            int deg=UnityEngine.Random.Range(0,360);
            for (int i=0;i<=ti;i++){
                GameObject bul=Instantiate(bullet1);
                basicbullet basb=bul.GetComponent<basicbullet>();
                basb.chplace(transform.localPosition.x,transform.localPosition.y);
                basb.chdeg(deg+i*360/ti);
                basb.chrotv(3f);
                basb.chv(3f);
                basb.chimg(star[UnityEngine.Random.Range(1,8)]);
            }
            }
            if(timer%10==0){
            GameObject bul1=Instantiate(bullet1);
            basicbullet basb1=bul1.GetComponent<basicbullet>();
            basb1.chplace(transform.localPosition.x,transform.localPosition.y);
            basb1.chdeg(towards);
            basb1.chrot(towards);
            basb1.chv(48f);
            basb1.chimg(aura);
            basb1.chscale(5,1); 
            basb1.chscv(5,10,5,8); 
            }
            
        }
    }
}
