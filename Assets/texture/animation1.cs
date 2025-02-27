using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class PlayAnimationOnCondition : MonoBehaviour
{
    private Animator animator;
    bool PlayAnimation = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ClickAction(){
            animator.SetBool("PlayAnimation", true); // 触发动画
            StartCoroutine(ShowAfterDelay());

        }
        private IEnumerator ShowAfterDelay()
    {
        // 等待2秒
        yield return new WaitForSeconds(3f);

        // 显示文本
                SceneManager.LoadScene("circuit2");
                Cursor.lockState = CursorLockMode.None;

    }
    }
