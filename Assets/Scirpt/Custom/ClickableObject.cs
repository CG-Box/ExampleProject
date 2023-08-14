using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public delegate void LeftClickDelegate(); 
    public delegate void RightClickDelegate();
    public delegate void MiddleClickDelegate();  
    public LeftClickDelegate LeftClickFunction;

    public RightClickDelegate RightClickFunction;

    public LeftClickDelegate MiddleClickFunction;
    void LeftClickAction()
    {
        LeftClickFunction?.Invoke();
    }
    void RightClickAction()
    {
        RightClickFunction?.Invoke();
    }
    void MiddleClickAction()
    {
        MiddleClickFunction?.Invoke();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            LeftClickAction();
        else if (eventData.button == PointerEventData.InputButton.Middle)
            MiddleClickAction();
        else if (eventData.button == PointerEventData.InputButton.Right)
            RightClickAction();
    }
}