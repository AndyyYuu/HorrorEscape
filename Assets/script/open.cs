using UnityEngine;

public class open : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator anim;
    public bool isopen = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ClickAction(){
        isopen = !isopen;
        anim.SetBool("Open", isopen);
    }
    void Update()
    {
        
    }
}
