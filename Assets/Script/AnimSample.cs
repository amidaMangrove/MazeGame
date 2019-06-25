using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSample : MonoBehaviour {

    //  Animator型を受け取る変数
    Animator animator;

    /// <summary>
    /// スタート。ゲームオブジェクト生成時に呼ばれる
    /// </summary>
    void Start()
    {
        //  アタッチされているAnimatorを取得
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        //  キー入力を受け取る
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("transition");
        }

        //  Aキーでアニメーションを停止
        if (Input.GetKeyDown(KeyCode.A)) {
            animator.speed = 0;
        }

        //  Sキーでアニメーションを再開
        if (Input.GetKeyDown(KeyCode.S)) {
            animator.speed = 1;
        }
    }

    //  オブジェクトを破棄
    public void AnimEnd()
    {
        Destroy(gameObject);
    }
}
