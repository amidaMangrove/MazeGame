using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 敵キャラのスクリプト
/// </summary>
public class Enemy : MonoBehaviour
{
    //  追跡の対象
    public GameObject targetObject;

    //  ナビメッシュエージェント
    NavMeshAgent navMeshAgent;

    void Start()
    {
        //  コンポーネントを取得
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        //  経路探索のパスが無効ではない場合
        if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) {

            //  ターゲットが存在しているか
            if (targetObject != null) {
                //  ナビメッシュの追跡座標を登録
                navMeshAgent.SetDestination(targetObject.transform.position);
            }
        }
    }
}
