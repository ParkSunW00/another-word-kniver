using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DocumentNumber : MonoBehaviour
{
	[SerializeField] UIDocument m_uiDocument;
	[SerializeField] List<Texture2D> m_numberImages = new();
	[SerializeField] string m_numberWrapperElementName = "NumberWrapperElement";

	VisualElement m_numberWrapperElement;

	private void Awake()
	{
		m_numberWrapperElement = m_uiDocument.rootVisualElement.Query<VisualElement>(m_numberWrapperElementName);
	}
	public void ResetNumberElements(int value)
	{
		m_numberWrapperElement.Clear();
		string valueString = value.ToString();
		for (int i = 0; i < valueString.Length; i++)
		{
			CreateChildNumberElement(int.Parse(valueString[i].ToString()));
		}
	}
	private VisualElement CreateChildNumberElement(int imageIndex)
	{
		VisualElement element = new();
		element.style.backgroundImage = m_numberImages[imageIndex];
		element.style.width = 52;
		element.style.maxWidth = 52;
		element.style.minWidth = 52;
		element.style.height = 76;
		element.style.maxHeight = 76;
		element.style.minHeight = 76;
		element.style.marginRight = -12;
		m_numberWrapperElement.Add(element);
		return element;
	}
}
