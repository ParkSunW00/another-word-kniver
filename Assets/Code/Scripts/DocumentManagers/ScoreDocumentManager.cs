using UnityEngine;
using UnityEngine.UIElements;

public class ScoreDocumentManager : MonoBehaviour
{
	[SerializeField] UIDocument m_uiDocument;
	
	Label m_scoreLabel;

	private void Start()
	{
		m_scoreLabel = m_uiDocument.rootVisualElement.Query<Label>("ScoreLabel");
		ScoreManager.ScoreChangedEvent.AddListener((score) => { m_scoreLabel.text = "Score: " + score; });
	}
}
