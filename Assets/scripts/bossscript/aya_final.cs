using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class aya_final : MonoBehaviour
{
    // Start is called before the first frame update
    float lastti=0f;
    float frame=0.016f;
    float deg=0;
    float degv=1.25f;
    int timer=0;
    int framed=1;
    GameObject bullet1=null;
    Sprite arrow;
    Sprite grain;
    
    void Start()
    {
        
        transform.localPosition=new Vector3(0,100,0);
        bullet1=Resources.Load("prefab/bulletclass") as GameObject;
        arrow=Resources.Load<Sprite>("arrow1") as Sprite;
        grain=Resources.Load<Sprite>("grain1") as Sprite;
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
            deg+=degv;
        }
        if(framed==1){
            if(timer%40==0){
                int ti=36;
                float sdeg=UnityEngine.Random.Range(0,360);
                for (int i=0;i<=ti;i++){
                    
                    GameObject bul=Instantiate(bullet1);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chdeg(sdeg+i*360/ti);
                    basb.chrot(sdeg+i*360/ti);
                    basb.chv(2f);
                    basb.chimg(grain);
                }
            }
            if((timer+5)%10==0){
                int ti=24;
                
                for (int i=0;i<=ti;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chrot(deg+i*360/ti);
                    basb.chdeg(deg+i*360/ti);
                    basb.chv(4f);
                    basb.chimg(arrow);
                }
                for (int i=0;i<=ti;i++){
                    GameObject bul=Instantiate(bullet1);
                    basicbullet basb=bul.GetComponent<basicbullet>();
                    basb.chplace(transform.localPosition.x,transform.localPosition.y);
                    basb.chrot(-(deg+i*360/ti));
                    basb.chdeg(-(deg+i*360/ti));
                    basb.chv(4f);
                    basb.chimg(arrow);
                }
            }
        }
    }
}
