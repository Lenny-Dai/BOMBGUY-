using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class basicbullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mcam;
    void Start()
    {
        mcam=GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        scrcheck();
    }
    void scrcheck(){
        if (mcam!=null){
            Camera cm=mcam.GetComponent<Camera>();
            
            float os = cm.orthographicSize;
            float lx=os* cm.aspect;
            float ly=os;
            float xx=cm.transform.localPosition.x;
            float yy=cm.transform.localPosition.y;
            float sx=transform.localPosition.x;
            float sy=transform.localPosition.y;
            if(sx<xx-lx||sx>xx+lx||sy<yy-ly||sy>yy+ly){
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D cld){
        //1:player 2:playerbullet 3:enemy 4:enemybullet
        datas other=cld.gameObject.GetComponent<datas>();
        datas self=GetComponent<datas>();
        if(other!=null){
            //if(other.group==)
        }
        
    }
    
    public void chplace(float x,float y){
        Vector3 vec=new Vector3(x,y,0);
        transform.localPosition=vec;
    }
    
    public void chv(float x){
        datas self=GetComponent<datas>();
        self.v=x;
    }
    public void chrotv(float x){
        datas self=GetComponent<datas>();
        self.rotv=x;
    }
    public void chdegv(float x){
        datas self=GetComponent<datas>();
        self.degv=x;
    }
    public void chdeg(float x){
        datas self=GetComponent<datas>();
        self.deg=x;
    }
    public void chrot(float x){
        datas self=GetComponent<datas>();
        self.rot=x;
    }
    public void chimg(Sprite x){
        SpriteRenderer spr=GetComponent<SpriteRenderer>();
        spr.sprite=x;
    }
}
