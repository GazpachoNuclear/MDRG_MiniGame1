using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public MiniGameManager2 manager;

	public void OnPointerDown(PointerEventData eventData)
	{
		manager.right = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		manager.right = false;
	}
}
