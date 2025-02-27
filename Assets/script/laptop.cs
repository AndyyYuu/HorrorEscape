using UnityEngine;

public class laptop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject on;
    public GameObject off;
    bool isOn = false;
    public void ClickAction(){
        isOn = !isOn;
        on.SetActive(isOn);
        off.SetActive(!isOn);
    }
}
