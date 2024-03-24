using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 此方法使用了固定时间（bunus time),可以考虑改成固定奖励个数
public class ControlBull : MonoBehaviour
{
    private float DeadTime; 
    private float CoolDownTime;
    private const float mintime = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        DeadTime = Time.time + 10f;
        CoolDownTime = -100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= DeadTime){
            Destroy(transform.gameObject);
        }
        if (Input.GetMouseButton(0))
        {
            if (Time.time - CoolDownTime > mintime){
                GameObject e1 = Instantiate(Resources.Load("prefabs/HeroBullet") as GameObject);
                GameObject e2 = Instantiate(Resources.Load("prefabs/HeroBullet") as GameObject);
                Vector3 screenPos = Input.mousePosition;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                CoolDownTime = Time.time;
                worldPos.z = 0;
                BulletScript script1 = e1.GetComponent<BulletScript>();
                if (script1 != null) 
                {
                    script1.dir = true;
                    script1.TargetP = worldPos;
                }
                BulletScript script2 = e2.GetComponent<BulletScript>();
                if (script2 != null) 
                {
                    script2.dir = false;
                    script2.TargetP = worldPos;
                }
            }
        }
    }
}
