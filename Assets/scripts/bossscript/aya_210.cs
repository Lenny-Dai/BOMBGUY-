using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aya_210 : MonoBehaviour
{
    // Start is called before the first frame update
    float lastti=0f;
    float frame=0.016f;
    float rdeg=0;
    int timer=0;
    int framed=1;
    bool fire=false;
    GameObject bullet1=null;
    Sprite arrow;
    Sprite grain2,grain3;
    
    void Start()
    {
        
        transform.localPosition=new Vector3(0,100,0);
        bullet1=Resources.Load("enemy/prefab/bullet_aya_210") as GameObject;
        grain2=Resources.Load<Sprite>("enemy/grain2") as Sprite;
        grain3=Resources.Load<Sprite>("enemy/grain3") as Sprite;
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
            
        }
        if(framed==1){
            if(timer%240==0){
                fire=true;
                rdeg=Random.Range(0,22.5f);
            }
            if(fire&&timer%4==0){
                int ti=16;
                for (int i=0;i<=ti;i++){
                    GameObject bul=Instantiate(bullet1);
                    bullet_aya_210 basb=bul.GetComponent<bullet_aya_210>();
                    basb.init(transform.localPosition.x,transform.localPosition.y,
                    5,rdeg+i*360/ti,1,grain2);
                }
                for (int i=0;i<=ti;i++){
                    
                    GameObject bul=Instantiate(bullet1);
                    bullet_aya_210 basb=bul.GetComponent<bullet_aya_210>();
                    basb.init(transform.localPosition.x,transform.localPosition.y,
                    5,rdeg+i*360/ti+11.25f,-1,grain3);
                }
            }
            if(timer%120==60){
                fire=false;
            }
        }
    }
}
