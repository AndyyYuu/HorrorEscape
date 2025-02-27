using UnityEngine;
using TMPro; 
using System.Collections; 

[RequireComponent(typeof(Rigidbody))]
public class DiceRoll : MonoBehaviour
{
    private Rigidbody body;

    [SerializeField] private float maxRandomForceValue = 10f;
    [SerializeField] private float startRollingForce = 5f;
    

    private float forceX, forceY, forceZ;
    public int diceFaceNum;
    Score score;
    public TextMeshProUGUI scoreText;
    public int counter = 0;

    private void Awake()
    {
        Initialize();
        
    }
    

    public void ClickAction(){
    
        if (body != null )
        {
            RollDice();
            
            StartCoroutine(ShowAfterDelay());
            

        }
    }
     private IEnumerator ShowAfterDelay()
    {
        // 等待2秒
        yield return new WaitForSeconds(3.5f);

        // 显示文本
        scoreText.gameObject.SetActive(true);
        counter++; 
    }

    private void RollDice()
    {
        body.isKinematic = false;

        forceX = Random.Range(0, maxRandomForceValue);
        forceY = Random.Range(0, maxRandomForceValue);
        forceZ = Random.Range(0, maxRandomForceValue);

        body.AddForce(Vector3.up * startRollingForce, ForceMode.Impulse);
        body.AddTorque(new Vector3(forceX, forceY, forceZ), ForceMode.Impulse);
    }

    private void Initialize()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        
    }
}