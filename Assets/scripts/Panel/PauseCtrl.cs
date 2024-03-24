using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseCtrl : MonoBehaviour
{
    public GameObject pausePanel;
    public Button returnBtn;
    public void OnMouseDown()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        returnBtn.onClick.AddListener(() =>
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
