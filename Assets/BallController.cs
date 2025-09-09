using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;

    //�E��ɕ\������scoretext
    private GameObject scoreText;
    //�X�R�A�v�Z�p�ϐ�
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //score��0�ŏ�����
        score = 0;
        //�V�[������scoretext�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");

        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //score0���X�V����
        this.scoreText.GetComponent<Text>().text = "SCORE:" + score.ToString();
        //�V�[������scoretext�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");

        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    //�Փ˂���tag�ɂ���ĈႤ�X�R�A�����Z����
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("�ՓˁF" + other.gameObject.tag);

        //�ȉ��̗l��Tag�𒲂ׂ�ƁA���ɏՓ˂���������ł��܂��B
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