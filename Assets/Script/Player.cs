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

    //  ゲームオーバーのUIオブジェクト
    public GameObject gameOver;

    //  フリーカメラを使用した移動
    public bool isFreeLook;

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


        if (isFreeLook) {
            // カメラの方向に対して平面方向の値を取得
            Vector3 forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 right = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;

            //  入力値を掛け合わせる
            forward = forward * z;
            right = right * x;

            //  2つのベクトルを加算し正規化
            var force = (forward + right).normalized;

            //  移動させる
            rigidBody.AddForce(force * speed);
        }
        else {

            rigidBody.AddForce(x * speed, 0, z * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidBody.AddForce(new Vector3(0,1,0) * 10, ForceMode.VelocityChange);
        }
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

        //  敵に衝突した場合
        if (collision.gameObject.tag == "Enemy") {
            Destroy(this.gameObject);
            gameOver.SetActive(true);
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
