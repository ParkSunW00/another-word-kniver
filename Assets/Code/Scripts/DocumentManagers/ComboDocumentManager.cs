using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ComboDocumentManager : MonoBehaviour
{
	[SerializeField] List<Texture2D> m_numberImages = new();
	[SerializeField] UIDocument m_uiDocument;

	VisualElement m_numberWrapperElement;
	List<VisualElement> m_numberElements = new();

	private void Awake()
	{
		m_numberWrapperElement = m_uiDocument.rootVisualElement.Query<VisualElement>("NumberWrapperElement");
	}
	private void Start()
	{
		ComboManager.ComboChangedEvent.AddListener((combo) =>
		{
			m_numberWrapperElement.Clear();
			string comboString = combo.ToString();
			for (int i = 0; i < comboString.Length; i++)
			{
				CreateChildNumberElement(int.Parse(comboString[i].ToString()));
			}
		});
	}
	private VisualElement CreateChildNumberElement(int imageIndex)
	{
		VisualElement element = new();
		element.name = CreateChildNumberElementName();
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
	private string CreateChildNumberElementName()
	{
		string name = "NumberElement0";
		m_numberElements.ForEach((_) => { name += "0"; });
		return name;
	}
}
