using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  クリックされたら
        if (Input.GetMouseButtonDown(0)) {
            //  マウスの座標を取得
            var position = Input.mousePosition;

            //  zに値を入れないとカメラに密着してしまうため適当な値
            position.z = 10;

            //  クリックした平面上の座標を3D空間に変換
            transform.position = Camera.main.ScreenToWorldPoint(position);
        }
    }
}
