using UnityEngine;
using UnityEngine.UI;

public class interaction : MonoBehaviour
{
    public LayerMask layer;
    int maxDistance = 15;
    public Image reticle;
    Transform camTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = new(camTrans.position,camTrans.forward);
            if(Physics.Raycast(ray, out RaycastHit hit, maxDistance, layer))
        {   GameObject clickedObj = hit.collider.gameObject;
        if (clickedObj.CompareTag("Clickable")){
            clickedObj.SendMessageUpwards("ClickAction");
        }
        SendMessage("ClickAction");
        }
    }
    }
    void FixedUpdate()
    {
        Ray ray = new(camTrans.position,camTrans.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, maxDistance, layer))
        {
            reticle.color = Color.red;
        }
        else{
            reticle.color = Color.white;
        }
    }
}
