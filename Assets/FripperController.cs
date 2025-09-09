using UnityEngine;
using UnityEngine.InputSystem;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //�����L�[�������������t���b�p�[�𓮂���
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame && this.gameObject.CompareTag("LeftFripperTag"))
        {
            SetAngle(this.flickAngle);
        }
        //�E���L�[�����������E�t���b�p�[�𓮂���
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame && this.gameObject.CompareTag("RightFripperTag"))
        {
            SetAngle(this.flickAngle);
        }

        //���L�[�����ꂽ���t���b�p�[�����ɖ߂�
        if (Keyboard.current.leftArrowKey.wasReleasedThisFrame && this.gameObject.CompareTag("LeftFripperTag"))
        {
            SetAngle(this.defaultAngle);
        }
        if (Keyboard.current.rightArrowKey.wasReleasedThisFrame && this.gameObject.CompareTag("RightFripperTag"))
        {
            SetAngle(this.defaultAngle);
        }
    }

    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}