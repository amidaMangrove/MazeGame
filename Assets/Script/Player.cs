using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //  RigidBody型でメンバ変数を宣言
    Rigidbody rigidBody;

    public float speed;

    public GameObject obj;

    //  AudioSource型でメンバ変数を宣言
    AudioSource audioSource;

    //  スコア
    int score = 0;

    public ScoreView scoreView;

    // Start is called before the first frame update
    void Start()
    {
        //  ゲームオブジェクトからアタッチされている
        //  RigidBodyコンポーネントを取得する
        rigidBody = GetComponent<Rigidbody>();

        //  オーディオソースのコンポーネントを取得する
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //  左右キーの入力を受け取る
        //  左(-1.0)～右(1.0)の範囲で取得
        float x = Input.GetAxis("Horizontal");

        //  上下キーの入力を受け取る
        //  左(-1.0)～右(1.0)の範囲で取得
        float z = Input.GetAxis("Vertical");

        rigidBody.AddForce(x * speed, 0, z * speed);
    }

    //  衝突開始時に呼ばれる
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item") {

            //  ゲームオブジェクトを生成する
            Instantiate(obj, collision.transform.position, Quaternion.identity);

            //  ゲームオブジェクトを破棄する
            Destroy(collision.gameObject);

            //  オーディオを再生する
            audioSource.Play();

            //  スコアを加算
            score++;

            //  画面のスコアを更新
            scoreView.UpdateScore(score);
            Debug.Log($"衝突開始:{collision.gameObject}");
        }
    }

    //  衝突中に呼ばれる
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Item") {
            Debug.Log($"衝突中:{collision.gameObject}");
        }
    }

    //  衝突終了時に呼ばれる
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Item") {
            Debug.Log($"衝突終了:{collision.gameObject}");
        }
    }

    // スライダーの値が変更したら呼ばれるメソッド
    //  valueにはスライダーの値が入ってくる
    public void ChangeScale(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }
}
