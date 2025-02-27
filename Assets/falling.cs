using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic; // 使用 List 来存储落下的 num
using TMPro; // 引入 TMP 命名空间

public class PieceMover : MonoBehaviour
{
    public GameObject targetObject; // 需要操控的物体
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool movingDown = true;
    public float moveSpeed = 2f;
    private Renderer objectRenderer;
     public TextMeshProUGUI Text; 
    public int chessNum;

    // 用来记录所有落下的 num
    public static readonly HashSet<int> targetNums = new HashSet<int> { 1, 5, 9, 6, 3, 8, 7 };

    // 共享的全局 HashSet，记录所有落下的棋子
    private static HashSet<int> fallingPieces = new HashSet<int>();

    void Start()
    {
        if (targetObject != null)
        {
            originalPosition = targetObject.transform.position;
            targetPosition = new Vector3(originalPosition.x, 0.42f, originalPosition.z);
            objectRenderer = targetObject.GetComponent<Renderer>();

            // 初始时隐藏物体
            targetObject.transform.position = originalPosition;
            objectRenderer.enabled = false;
        }
    }

    public void ClickAction()
    {
        if (targetObject != null)
        {
            StopAllCoroutines(); // 确保不会有多个协程同时运行
            if (movingDown)
            {
                objectRenderer.enabled = true; // 显示物体
                StartCoroutine(MovePiece(targetPosition));
            }
            else
            {
                StartCoroutine(MovePieceAndHide(originalPosition));
            }
            movingDown = !movingDown; // 切换状态
        }
    }

    IEnumerator MovePiece(Vector3 destination)
    {
        // 逐步移动直到距离目标点非常接近
        while (Vector3.Distance(targetObject.transform.position, destination) > 0.01f)
        {
            targetObject.transform.position = Vector3.Lerp(targetObject.transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }
        // 确保物体最终停留在目标位置
        targetObject.transform.position = destination;
    }

    IEnumerator MovePieceAndHide(Vector3 destination)
    {
        // 逐步移动直到距离目标点非常接近
        while (Vector3.Distance(targetObject.transform.position, destination) > 0.01f)
        {
            targetObject.transform.position = Vector3.Lerp(targetObject.transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }
        // 确保物体最终回到原位置
        targetObject.transform.position = destination;
        objectRenderer.enabled = false; // 隐藏物体
    }

    // 在触发器内时调用
    private void OnTriggerEnter(Collider other)
    {
        // 通过检测物体的速度来判断它是否已经停止
        
            // 获取当前落下物体的 num（假设物体的名称就是对应的 num）
            int pieceNum = int.Parse(other.name);
            
            // 如果这个 num 不在已记录的集合中，记录它
            if (!fallingPieces.Contains(pieceNum))
            {
                fallingPieces.Add(pieceNum);
                Debug.Log("Piece " + pieceNum + " added.");

                // 检查是否满足胜利条件
                Debug.Log("fallingPieces: " + string.Join(", ", fallingPieces));
            Debug.Log("targetNums: " + string.Join(", ", targetNums));
                CheckVictory();
            }
        }
    

    // 检查是否已经达到胜利条件
    private void CheckVictory()
    {
        HashSet<int> targetSet = new HashSet<int>(targetNums);
        // 判断 fallingPieces 是否与 targetNums 完全一致
        if (fallingPieces.SetEquals(targetSet))
        {
            Debug.Log("Victory! All pieces are in place.");
            Text.gameObject.SetActive(true);

            // 你可以在这里执行胜利后的行为，例如显示胜利界面等
        }
    }

    // 当物体离开触发器时移除该 num
    private void OnTriggerExit(Collider other)
    {
        int pieceNum = int.Parse(other.name);
        if (fallingPieces.Contains(pieceNum))
        {
            fallingPieces.Remove(pieceNum);
            Debug.Log("Piece " + pieceNum + " removed.");
            CheckVictory();
        }
    }
}