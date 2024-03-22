using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] DoorOp;
    private int Doorcnt;
    private SpriteRenderer DoorRender;  

    IEnumerator DoChangeSprite()
    {
        while (Doorcnt < DoorOp.Length)
        {
            DoorRender.sprite = DoorOp[Doorcnt];
            Doorcnt++;
            yield return new WaitForSeconds(1f); //等待一秒
        }
    }
    void Awake()
    {
        Doorcnt = 0;
        transform.position = new Vector3 (0, 25, 10);
        DoorRender = GetComponent<SpriteRenderer>();
        StartCoroutine(DoChangeSprite());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
