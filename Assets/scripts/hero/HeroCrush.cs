using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

public class HeroCrush : MonoBehaviour
{
    private GameObject e;
    public bool intersect;//是否在拿东西
    private bool obtainable;//目前的资源能不能拿
    private int[] obtains = new int[2];
    private bool choose;
    private int hold;
    private int objnum;
    public Resource1 r1 = null;
    public Resource2 r2 = null;
    public Resource3 r3 = null;

    // Start is called before the first frame update
    void Start()
    {
        objnum = 0;
        hold = 0;
        choose = false;
        intersect = false;
        obtainable = false;
        obtains[0] = 0; // 给数组的第一个元素赋值为0
        obtains[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO 这里写不同属性的合成
    }

    public int getobjNum(){
        return objnum;
    }

    public int gethold(){
        return hold;
    }

    public bool getobtain(){
        return obtainable;
    }

    public bool getchoose(){
        return choose;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        intersect = true;
        if(objnum >= 2){
        }else{   
            // Debug.Log(hold);         
            if(collision.gameObject.name == "Resource1" && hold != 1){
                e = Instantiate(Resources.Load("prefabs/gold") as GameObject);
                r1.hint();
                hold = 1;
            }

            if(collision.gameObject.name == "Resource2" && hold != 2){
                e = Instantiate(Resources.Load("prefabs/W") as GameObject);
                r2.hint();
                hold = 2;
            }

            if(collision.gameObject.name == "Resource3" && hold != 3){
                e = Instantiate(Resources.Load("prefabs/M") as GameObject);
                r3.hint();
                hold = 3;
            }
            // TODO 在这里写碰到其他三个角怎么办
            if (e != null){
                obtainable = true; 
                if (objnum == 0){
                    e.transform.localPosition = transform.localPosition + new Vector3(-17, 50, 0);
                }else{
                    e.transform.localPosition = transform.localPosition + new Vector3(17, 50, 0);
                }
            }
        }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("choose:"+choose);
        if(!choose && obtainable){
            Debug.Log("Allow you to type1!"); 
            if(objnum < 2){  
                Debug.Log("Allow you to type2!" + objnum);        
                if (Input.GetKey(KeyCode.Q)){
                    Debug.Log("Allow you to type332!");
                    choose = true;
                    obtains[objnum++] = hold;
                    obtainable = false;
                    if(hold == 1)r1.collapse();
                    if(hold == 2)r2.collapse();
                    if(hold == 3)r3.collapse();
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        intersect = false;
        if (!choose){
            if(objnum == 0){
                hold = 0;
            }else{
                hold = obtains[objnum-1];
            }
        }
        choose = false;
        obtainable = false;
    }

}
