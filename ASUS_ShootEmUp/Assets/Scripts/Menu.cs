using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // This is called when the pointer enters the button area.
        animator.SetBool("hover", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // This is called when the pointer exits the button area.
        animator.SetBool("hover", false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // This is called when the pointer clicks the button.
        // Set "hover" to false because the button is being pressed, not just hovered over.
        animator.SetBool("hover", false);

        // If you have a "pressed" trigger or bool in your animator, you can set it here.
        // For example, if "pressed" is a trigger:
        animator.SetBool("pressed", true);

        // You might want to reset the "pressed" state after a short delay or when the button is released.
        // This is not shown here and will depend on the specifics of your animation states.
    }

    // Optionally, you can implement OnPointerUp and OnPointerDown to handle those specific events.
    // ...
}
