using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    //  追跡する目標
    public GameObject target;

    //  カメラと目標の距離
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        //  起動時に距離を計測
        distance = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //  線形補間を使用し一定の距離を保つようにする
        transform.position = Vector3.Lerp(transform.position, target.transform.position + distance, Time.deltaTime);
    }
}
