using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 此方法使用了固定时间（bunus time),可以考虑改成固定奖励个数
public class NormalController : MonoBehaviour
{
    private float DeadTime; 
    private float CoolDownTime;
    private const float mintime = 0.25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - CoolDownTime > mintime){
                GameObject e1 = Instantiate(Resources.Load("prefabs/NormalBullet") as GameObject);
                Vector3 screenPos = Input.mousePosition;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                CoolDownTime = Time.time;
                worldPos.z = 0;
                NormalBullet script1 = e1.GetComponent<NormalBullet>();
                if (script1 != null) 
                {
                    script1.dir = true;
                    script1.TargetP = worldPos;
                }
            }
        }
    }
}
