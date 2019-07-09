using UnityEngine;

public class RayHitSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  オブジェクトの向いている方向にレイを飛ばす
        Ray ray = new Ray(transform.position, transform.forward);

        //  レイの交差情報を保持
        RaycastHit rayCastHit;
        
        //  レイの交差判定
        if( Physics.Raycast(ray, out rayCastHit)) {

            //  rayCastHit.colliderに交差したオブジェクトの情報が入っている
            var renderer = rayCastHit.collider.gameObject.GetComponent<Renderer>();

            //  交差したオブジェクトの色を赤に変える
            renderer.material.color = Color.red;
        }

        //  デバッグ用にレイを描画
        Debug.DrawRay(transform.position, transform.forward * 100);

    }
}
