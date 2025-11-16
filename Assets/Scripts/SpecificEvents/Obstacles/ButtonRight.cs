using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public MiniGameManager2 manager;
	public Animator playerAnimator;

	public void OnPointerDown(PointerEventData eventData)
	{
		manager.right = true;
		playerAnimator.SetBool("Right", true);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		manager.right = false;
		playerAnimator.SetBool("Right", false);
	}
}
