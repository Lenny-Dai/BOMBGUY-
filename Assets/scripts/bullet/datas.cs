using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class datas : MonoBehaviour
{
    // Start is called before the first frame update
    public int group=0;
    public float v=0;
    public float rotv=0;
    public float degv=0;
    public float deg=0;
    public float rot=0;
    public float hp=10f;
    public float a=4;
    public float b=4;
    public int phase=0;
    //deg是速度，rot是贴图
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //updatepos
        Vector3 pos=transform.localPosition;
        pos.x+=(float)Math.Cos(deg*3.14/180f)*v*Time.smoothDeltaTime*60;
        pos.y+=(float)Math.Sin(deg*3.14/180f)*v*Time.smoothDeltaTime*60;
        transform.localPosition=pos;

        //updaterot
        rot+=rotv*Time.smoothDeltaTime*60;
        Quaternion qr=transform.localRotation;
        Vector3 r=qr.eulerAngles;
        r.z=rot;
        transform.localRotation=Quaternion.Euler(r);
        if(rot>360){
            rot-=360;
        }
        if(rot<-360){
            rot+=360;
        }

        //updatedeg
        deg+=degv*Time.smoothDeltaTime*60;
        if(deg>360){
            deg-=360;
        }
        if(deg<-360){
            deg+=360;
        }

        //updatecolli
        BoxCollider2D colli=GetComponent<BoxCollider2D>();
        colli.size=new Vector2(a,b);
        

    }
}
