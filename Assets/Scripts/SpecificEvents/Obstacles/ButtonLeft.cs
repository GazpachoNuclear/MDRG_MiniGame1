using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	public MiniGameManager2 manager;
	public Animator playerAnimator;

	public void OnPointerDown(PointerEventData eventData)
	{
		manager.left = true;
		playerAnimator.SetBool("Left", true);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		manager.left = false;
		playerAnimator.SetBool("Left", false);
	}
}
