using UnityEngine;
using TMPro; // 引入 TMP 命名空间
using System.Collections;


    

    public class Score : MonoBehaviour
{
    public DiceRoll dice;  // 你的 DiceRoll 类的实例
     public TextMeshProUGUI scoreText; // 使用 TMP 组件
     int currentRoll;
     public GameObject targetObject; 
    // 在 Inspector 中拖入带有 Animator 的对象
    private Animator animator;
    public GameObject image1; // 第一张 Image
    public GameObject image2; // 第二张 Image
     private bool isObjectActive = false;
    
     


    private bool isFirstRoll = true;
    private void Awake()
    {
        dice = FindObjectOfType<DiceRoll>();
        
    }
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
    
          
    
    

    public void Update()
{
    if (dice != null && dice.counter == 1 && isFirstRoll)
    {
        // 获取当前掷骰子的结果
        currentRoll = dice.diceFaceNum;
        isFirstRoll = false; 

        // 将当前结果添加到列表中
        // 这里可以将掷骰结果加入列表（如果有必要）

        // 更新显示文本为当前的结果
        scoreText.text = "Your Score:"+ currentRoll.ToString();
        isObjectActive=false;
    }

    if (dice.counter == 2)
    {
        // 显示当前和第二次的掷骰结果
        scoreText.text = currentRoll.ToString() + ":" + dice.diceFaceNum.ToString();

        // 等待协程
        

        // 比较结果并更新文本
        if (dice.diceFaceNum > currentRoll)
        {
            
            scoreText.text = "LOSER!HAHAHA!Another Round!";
            dice.counter = 0;
            
            isFirstRoll = true;
            if(!isObjectActive){
              targetObject.SetActive(true);
              isObjectActive=true;}
       
        if (animator != null)
        {
            animator.SetBool("Horror", true);
            StartCoroutine(wait()); 
             
            // 触发动画
        }
        else
        {
            Debug.LogError("目标对象的 Animator 组件未找到！");
        }
        }
        else if (dice.diceFaceNum < currentRoll)
        {
            
            scoreText.text = "You Win...";
            image1.SetActive(true); // 显示第一张图片
        image2.SetActive(true);
        StartCoroutine(wait2());  
        }
        else
        {
            scoreText.text = "Another Round";
            dice.counter = 0;
            
            isFirstRoll = true;
             if(!isObjectActive){
              targetObject.SetActive(true);
              isObjectActive=true;}
       
        if (animator != null)
        {
            animator.SetBool("Horror", true); 
            StartCoroutine(wait());
            
            // 触发动画
        }
        else
        {
            Debug.LogError("目标对象的 Animator 组件未找到！");
        }
        }
        
    }
}
        
private IEnumerator wait(){
            yield return new WaitForSeconds(4f);
            targetObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            scoreText.text = "";
        }
private IEnumerator wait2(){
            yield return new WaitForSeconds(4f);
            
            scoreText.gameObject.SetActive(false);
            scoreText.text = "";
        }
        

    }
    

 
