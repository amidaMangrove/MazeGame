using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSample : MonoBehaviour
{   
    void Start()
    {
        //  ボタンオブジェクトを取得
        var button = GetComponent<Button>();

        //  ボタン押下時のイベントを登録
        button.onClick.AddListener(() =>
        {
            Debug.Log("ボタンが押された！");
        });
    }
}
