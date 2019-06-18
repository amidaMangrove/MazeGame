using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISample : MonoBehaviour
{
    //  アイテム
    public GameObject item; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ボタンが押された処理。アイテムを生成する
    /// </summary>
    public void CreateItem()
    {
        //  xとzの値を -5～5の範囲でランダムに決める
        float x = Random.Range(-5f,5f);
        float z = Random.Range(-5f, 5f);

        //  ゲームオブジェクトを生成
        Instantiate(item, new Vector3(x, 0.5f, z), Quaternion.identity);
    }
}
