using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicBaseScript : MonoBehaviour, IPointerMoveHandler
{
    [SerializeField] LayerMask mask;
    public void OnPointerMove(PointerEventData eventData)
    {
        
        var hir = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition),10f, mask);
        MagicMenuButtons m;
        Debug.Log(hir.point.x);
        if (hir.collider == null) return;
        Debug.Log("Collider");
        if (hir.collider.TryGetComponent<MagicMenuButtons>(out m))
        {
            Debug.Log("Button");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
