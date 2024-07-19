using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ChatManager : MonoBehaviour
{

    public Image dialogueBoxA; // 대화자 A의 대화창 이미지
    public Image dialogueBoxB; // 대화자 B의 대화창 이미지
    public Text dialogueText; // 대화 텍스트

    private Queue<Dialogue> dialogues; // 대화 문장을 저장할 큐

    [System.Serializable]
    public class Dialogue
    {
        public string speaker; // 대화자
        public string sentence; // 대화 문장
    }

    void Start()
    {
        dialogues = new Queue<Dialogue>();

        // 테스트용 대화 문장
        //A=기사 , B=신 
        dialogues.Enqueue(new Dialogue { speaker = "A", sentence = "난… 죽은건가?" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "흠흠 네놈이 내가 점지해놓은 용사 후보생을 죽였으니 \n곱게는 죽지 못하지" });
        dialogues.Enqueue(new Dialogue { speaker = "A", sentence = "당신은.. 신인가요?" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "그렇다 진부한 이러저러한 설명은 집어치워두고 \n넌 이제 용사를 죽인 댓가로 기사가 되어야겠다." });
        dialogues.Enqueue(new Dialogue { speaker = "A", sentence = "(기사..? 멋진거 같기도…) 그런데 저에게 그런 자격이 있나요" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "당연하지 이미 그대는 면허가 있지 않은가?" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "넌 기사가 되어서, " });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "나 대신 내가 점지해놓은 용사를 트럭으로 전송시켜 \n이세계의 평화를 지키는 기사가 되어야한다." });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "난 자비로우니, 네가 처치한 사람의 수명을 너에게 주도록 하지" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "대신 그 수명은 온전히 일하는것에 써야하니 \n생존을 위해서는일을 멈추면 안될것이야" });
        dialogues.Enqueue(new Dialogue { speaker = "A", sentence = "잠시만 기사가 그 기사인…" });
        dialogues.Enqueue(new Dialogue { speaker = "B", sentence = "자 가거라 나의 기사여!! \n너의 생존을 위해 이세계를 지키는 훌륭한 기사가 되거라!!" });

        // 첫 번째 대화 문장
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
