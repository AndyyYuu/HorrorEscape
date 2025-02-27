using UnityEngine;
using System.Collections;

public class DisappearAfterAnimation : StateMachineBehaviour
{
    public float delay = 2f; // 动画结束后延迟多少秒再消失
    public GameObject targetObject; // 目标 GameObject

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 获取动画控制的 GameObject
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 确保 MonoBehaviour 组件调用协程
        targetObject.SetActive(false);
    }

    
}
