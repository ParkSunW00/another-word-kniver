using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ChatManager : MonoBehaviour
{

    public Image dialogueBoxA; // ��ȭ�� A�� ��ȭâ �̹���
    public Image dialogueBoxB; // ��ȭ�� B�� ��ȭâ �̹���
    public Text dialogueText; // ��ȭ �ؽ�Ʈ

    private Queue<Dialogue> dialogues; // ��ȭ ������ ������ ť

    [System.Serializable]
    public class Dialogue
    {
        public string speaker; // ��ȭ��
        public string sentence; // ��ȭ ����
    }

    void Start()
    {
        dialogues = new Queue<Dialogue>();

        // �׽�Ʈ�� ��ȭ ����
        //A=��� , B=�� 
        dialogues.Enqueue(new Dialogue { speaker = "A", sentence = "���� �����ǰ�?" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "���� �׳��� ���� �����س��� ��� �ĺ����� �׿����� \n���Դ� ���� ������" });
        dialogues.Enqueue(new Dialogue { speaker = "A", sentence = "�����.. ���ΰ���?" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "�׷��� ������ �̷������� ������ ����ġ���ΰ� \n�� ���� ��縦 ���� �񰡷� ��簡 �Ǿ�߰ڴ�." });
        dialogues.Enqueue(new Dialogue { speaker = "A", sentence = "(���..? ������ ���⵵��) �׷��� ������ �׷� �ڰ��� �ֳ���" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "�翬���� �̹� �״�� ���㰡 ���� ������?" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "�� ��簡 �Ǿ, " });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "�� ��� ���� �����س��� ��縦 Ʈ������ ���۽��� \n�̼����� ��ȭ�� ��Ű�� ��簡 �Ǿ���Ѵ�." });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "�� �ں�ο��, �װ� óġ�� ����� ������ �ʿ��� �ֵ��� ����" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "��� �� ������ ������ ���ϴ°Ϳ� ����ϴ� \n������ ���ؼ������� ���߸� �ȵɰ��̾�" });
        dialogues.Enqueue(new Dialogue { speaker = "A", sentence = "��ø� ��簡 �� ����Ρ�" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "�� ���Ŷ� ���� ��翩!! \n���� ������ ���� �̼��踦 ��Ű�� �Ǹ��� ��簡 �ǰŶ�!!" });

        // ù ��° ��ȭ ����
        DisplayNextSentence();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue dialogue = dialogues.Dequeue();
        UpdateDialogueBox(dialogue.speaker);
        dialogueText.text = dialogue.sentence;
    }

    void UpdateDialogueBox(string speaker)
    {
        if (speaker == "A")
        {
            dialogueBoxA.gameObject.SetActive(true);
            dialogueBoxB.gameObject.SetActive(false);
        }
        else if (speaker == "B")
        {
            dialogueBoxA.gameObject.SetActive(false);
            dialogueBoxB.gameObject.SetActive(true);
        }
    }

    void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false);
        dialogueBoxA.gameObject.SetActive(false);
        dialogueBoxB.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");

    }
}
