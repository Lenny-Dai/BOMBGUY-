using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picture : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite[] stand=new Sprite[10];
    Sprite[] move=new Sprite[10];
    float ltime=0;
    int cnt=0;
    void Start()
    {
        for(int i=0;i<4;i++){
            stand[i]=Resources.Load<Sprite>("enemy/fairy_y/fy_"+(i+1)) as Sprite;
            if(stand[i]==null){
                Debug.Log("kksk");
            }
        }
        for(int i=0;i<4;i++){
            move[i]=Resources.Load<Sprite>("enemy/fairy_y/fym_"+(i+1)) as Sprite;
            if(stand[i]==null){
                Debug.Log("kksk");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        basicbullet basb=gameObject.GetComponent<basicbullet>();
        if(Time.time-ltime>0.2){
            ltime=Time.time;
            cnt=(cnt+1)%4;
            float v=gameObject.GetComponent<datas>().v;
            if(v!=0){
                basb.chimg(move[cnt]);
                float deg=gameObject.GetComponent<datas>().deg;
                float muls=3;
                if(deg<180&&deg>-180){
                    basb.chscale(1f*muls,1f*muls);
                }
                else{
                    basb.chscale(-1f*muls,1f*muls);
                }
            }
            else{
                if(basb==null){
                Debug.Log("kksk");
            }
                basb.chimg(stand[cnt]);
            }
        }
    }
}
