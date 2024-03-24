using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private Text scoreTxt;
    private float score = 0;

    private float Timer;

    private float perScore = 10;
    void Start()
    {
        scoreTxt = GetComponent<Text>();
        score = 0;
        scoreTxt.text = "分数：0";
        ResetPerScore();

    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 1)
        {
            Timer = 0;
            if (score < 100000)
            {
                score += perScore;
                SetScoreText(score);

                perScore += 10;
                if (perScore >= 1000)
                {
                    perScore = 1000;
                }
            }
        }
    }

    /// <summary>
    /// 设置分数文本
    /// </summary>
    /// <param name="score"></param>
    public void SetScoreText(float score)
    {
        scoreTxt.text = "分数：" + score;
    }

    /// <summary>
    /// 重置每秒增加的分数
    /// </summary>
    public void ResetPerScore()
    {
        perScore = 10;
    }

    /// <summary>
    /// 增加分数
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(float score)
    {
        this.score += score;
        SetScoreText(this.score);
    }
}
