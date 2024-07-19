using UnityEngine;
using UnityEngine.UIElements;

public class TimeLimitDocumentManager : MonoBehaviour
{
	[SerializeField] UIDocument m_uiDocument;

	ProgressBar m_progressBar;

	private void Start()
	{
		m_progressBar = m_uiDocument.rootVisualElement.Query<ProgressBar>("TimeLimitProgressBar");
		TimeLimitManager.TimeLimitChangedEvent.AddListener((timeLimit) => { m_progressBar.value = timeLimit; });
		TimeLimitManager.TimeLimitResetedEvent.AddListener((timeLimit) => { m_progressBar.highValue = timeLimit; });
	}
}
