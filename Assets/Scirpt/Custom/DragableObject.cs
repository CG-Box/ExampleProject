using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
 
public class DragableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public delegate void DropOnObjectDelegate(); 

    public DropOnObjectDelegate DropOnObjectFunction;

    Image dragImage;

    Transform parentAfterDrag;

    Vector3 startPosition;

    int counter = 0;

    void Awake() {
        dragImage = GameObject.Find("ItemImage").GetComponent<Image>();
    }

    void DropOnObjectAction()
    {
        DropOnObjectFunction?.Invoke();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        startPosition = transform.position;
        //transform.SetParent(transform.root);
        //transform.SetAsFirstSibling();
        //dragImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Mouse.current.position.ReadValue();   
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        transform.position = startPosition;
        dragImage.raycastTarget = true;
        CheckPosition();
    }

    public void SetParentTransform(Transform newParent)
    {
        parentAfterDrag = newParent;
    }
    
    void CheckPosition()
    {
        Transform target = null;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
        {
            DropOnObjectAction();
            target = hit.collider.transform;
            var deadZone = target.GetComponent<DeadZone>();
            if(deadZone != null)
            {
                counter++;
                Color newColor;
                if(counter%2 == 0)
                {
                    newColor = new Color (132, 255, 0);
                }
                else
                {
                    newColor = new Color (0, 115, 255);
                }
                target.GetComponent<SpriteRenderer>().color = newColor;
            }
        }

        if (target != null)
        {
            //target.position = worldPoint;
        }
    }
}