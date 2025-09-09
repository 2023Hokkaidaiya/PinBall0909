using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //右上に表示するscoretext
    private GameObject scoreText;
    //スコア計算用変数
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //scoreを0で初期化
        score = 0;
        //シーン中のscoretextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //score0を更新する
        this.scoreText.GetComponent<Text>().text = "SCORE:" + score.ToString();
        //シーン中のscoretextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    //衝突したtagによって違うスコアを加算する
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("衝突：" + other.gameObject.tag);

        //以下の様にTagを調べると、何に衝突したか判定できます。
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 1000;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 100;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 3000;
        }

    }
}