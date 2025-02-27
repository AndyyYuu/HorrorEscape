using UnityEngine;

public class chessing : MonoBehaviour
{
    public GameObject targetObject; // 在 Inspector 中拖入带有 Animator 的对象
    private Animator animator;
    public int chessNum;

    void Start()
    {
        if (targetObject != null)
        {
            animator = targetObject.GetComponent<Animator>(); // 获取目标对象的 Animator
        }
        else
        {
            Debug.LogError("目标对象未设置！");
        }
    }

    public void ClickAction()
    {
        targetObject.SetActive(true);
        if (animator != null)
        {
            animator.SetBool("Fall", true); 
            chessNum = int.Parse(targetObject.name);// 触发动画
        }
        else
        {
            Debug.LogError("目标对象的 Animator 组件未找到！");
        }
    }
}