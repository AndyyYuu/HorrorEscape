using UnityEngine;

public class animationhorror : MonoBehaviour
{
    public GameObject targetObject; 
    public GameObject targetObject2;// 在 Inspector 中拖入带有 Animator 的对象
    private Animator animator;
    

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
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            targetObject.SetActive(true);
        targetObject2.SetActive(true);
        if (animator != null)
        {
            animator.SetBool("Horror", true); 
            // 触发动画
        }
        else
        {
            Debug.LogError("目标对象的 Animator 组件未找到！");
        }
    }

}
}
