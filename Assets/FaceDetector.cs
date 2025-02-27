using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    DiceRoll dice;

    private void Awake()
    {
        dice = FindObjectOfType<DiceRoll>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (dice != null)
        {
            // **错误1修正：缺少 GetComponent<> 语法的正确调用**
            if (dice.GetComponent<Rigidbody>().linearVelocity == Vector3.zero)
            {
                // **错误2修正：应该使用 int.Parse() 而不是 int Parse()**
                dice.diceFaceNum = int.Parse(other.name);
            }
        }
    }
}