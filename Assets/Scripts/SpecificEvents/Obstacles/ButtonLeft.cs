using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	public MiniGameManager2 manager;

	public void OnPointerDown(PointerEventData eventData)
	{
		manager.left = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		manager.left = false;
	}
}
