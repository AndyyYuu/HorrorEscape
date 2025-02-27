using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RotateImage : MonoBehaviour
{
    private bool isCorrect = false; // 标记旋转是否正确
    public float targetAngle; // 目标角度
    public float rotationAngle = 90f; // 每次旋转的角度

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Rotate); // 按钮点击事件绑定旋转方法
    }
    

    public void Rotate()
    {
        transform.Rotate(0, 0, rotationAngle); // 每次旋转指定的角度
        CheckRotation(); // 旋转后检查
    }

    void CheckRotation()
    {
        // 获取当前物体的旋转角度，保持在 0~360 范围内
        float zRotation = Mathf.Repeat(transform.eulerAngles.z, 360f);
        

        // 判断当前角度是否接近目标角度
        if (Mathf.Abs(zRotation - targetAngle) < 5f)
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
        Debug.Log(isCorrect);

        // 每次旋转后检查所有物体的状态
        CheckAllCorrect();
    }

    // 返回物体是否处于正确状态
    public bool IsCorrect()
    {
        return isCorrect;
    }

    void CheckAllCorrect()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("rotatable"); // 查找所有带 "rotatable" 标签的物体

        foreach (GameObject obj in taggedObjects)
        {
            RotateImage piece = obj.GetComponent<RotateImage>(); // 获取 RotateImage 组件
            if (piece != null && !piece.IsCorrect()) // 如果有一个不正确，返回
            {
                return;
            }
        }

        // 如果所有物体都正确，触发成功
        Debug.Log("所有物体旋转正确，成功触发！");
         SceneManager.LoadScene("circuit2");

        // 这里可以加成功动画、解锁机关等
    }
    void FixedUpdate(){
        CheckAllCorrect();
    }
}
