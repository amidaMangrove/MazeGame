using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject goalEffect;

    //  ゴールのテキスト
    public GameObject goalText;
    public void OnTriggerEnter(Collider other)
    {
        Instantiate(goalEffect, new Vector3(0, 0, 0), Quaternion.Euler(-90.0f,0,0));

        //  ゴールのゲームオブジェクトアクティブに
        goalText.SetActive(true);
        Destroy(this.gameObject);
    }
}
