using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    //  Textコンポーネント
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //  Textコンポーネントを取得する
        scoreText = GetComponent<Text>();
    }

    /// <summary>
    /// テキストを更新する
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        //  「text」を書き換えることで表示するテキストを更新
        scoreText.text = "Score : " + score;
    }
}
