using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(120, 120, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        transform.localPosition = p;
        if (Input.GetMouseButtonDown(0))
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.6f, transform.localScale.y * 0.6f, transform.localScale.z * 0.6f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = new Vector3(120, 120, 2);
        }
    }
}
