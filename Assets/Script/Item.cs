using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    //  アニメーション終了時にイベントで呼ばれる
    void AnimEnd()
    {
        Destroy(this.gameObject);
    }

    //  衝突判定
    public void OnCollisionEnter(Collision collision)
    {
        //  衝突したら当たり判定を無効にする
        gameObject.GetComponent<Collider>().enabled = false;

        //  トリガーを起こす
        animator.SetTrigger("Get");
    }
}
