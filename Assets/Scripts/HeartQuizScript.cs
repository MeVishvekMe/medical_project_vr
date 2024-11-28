using System.Collections.Generic;
using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartQuizScript : MonoBehaviour {
    public TextMeshProUGUI questionText;
    public List<string> stringList = new List<string>();
    public List<int> answers = new List<int>();

    public Button option1;
    public Button option2;
    public Button option3;
    public Button option4;

    private HashSet<int> _askedQuestions = new HashSet<int>();
    private int _currentQuestion;

    private int _score = 0;
    public TextMeshProUGUI scoreText;
    void Start() {
        // Hardcode the questions into the list
        stringList.Add("Which artery is the first major branch off the aortic arch?\n" +
                       "   - A) Left Subclavian Artery\n" +
                       "   - B) Left Common Carotid Artery\n" +
                       "   - C) Right Brachiocephalic Vein\n" +
                       "   - D) Brachiocephalic Artery\n");
        answers.Add(4); // Correct: Brachiocephalic Artery

        stringList.Add("What is the main role of the left common carotid artery?\n" +
                       "   - A) To supply blood to the left arm\n" +
                       "   - B) To supply blood to the left side of the head and neck\n" +
                       "   - C) To transport deoxygenated blood from the left side\n" +
                       "   - D) To carry blood from the left lung\n");
        answers.Add(2); // Correct: To supply blood to the left side of the head and neck

        stringList.Add("Which blood vessel supplies oxygenated blood to the left arm?\n" +
                       "   - A) Left Subclavian Artery\n" +
                       "   - B) Left Common Carotid Artery\n" +
                       "   - C) Brachiocephalic Artery\n" +
                       "   - D) Right Brachiocephalic Vein\n");
        answers.Add(1); // Correct: Left Subclavian Artery

        stringList.Add("Where does the right brachiocephalic vein carry blood from?\n" +
                       "   - A) Right arm, head, and neck\n" +
                       "   - B) Left side of the head\n" +
                       "   - C) Lower body\n" +
                       "   - D) Left arm\n");
        answers.Add(1); // Correct: Right arm, head, and neck

        stringList.Add("What is the primary function of the aorta?\n" +
                       "   - A) To carry deoxygenated blood to the heart\n" +
                       "   - B) To pump blood to the lungs\n" +
                       "   - C) To distribute oxygenated blood to the body\n" +
                       "   - D) To collect blood from the body\n");
        answers.Add(3); // Correct: To distribute oxygenated blood to the body

        stringList.Add("Which chamber of the heart pumps blood into the aorta?\n" +
                       "   - A) Right Atrium\n" +
                       "   - B) Left Atrium\n" +
                       "   - C) Right Ventricle\n" +
                       "   - D) Left Ventricle\n");
        answers.Add(4); // Correct: Left Ventricle

        stringList.Add("Where does the superior vena cava transport blood?\n" +
                       "   - A) From the lungs to the heart\n" +
                       "   - B) From the upper body to the right atrium\n" +
                       "   - C) From the left atrium to the left ventricle\n" +
                       "   - D) From the heart to the body\n");
        answers.Add(2); // Correct: From the upper body to the right atrium

        stringList.Add("Which heart valve is located between the right atrium and right ventricle?\n" +
                       "   - A) Pulmonary Valve\n" +
                       "   - B) Tricuspid Valve\n" +
                       "   - C) Bicuspid Valve\n" +
                       "   - D) Aortic Valve\n");
        answers.Add(2); // Correct: Tricuspid Valve

        stringList.Add("What is the interventricular septum?\n" +
                       "   - A) A valve separating the left atrium and left ventricle\n" +
                       "   - B) A muscle that pumps blood to the lungs\n" +
                       "   - C) The wall separating the left and right ventricles\n" +
                       "   - D) The partition between the atria\n");
        answers.Add(3); // Correct: The wall separating the left and right ventricles

        stringList.Add("Which blood vessel carries oxygen-rich blood from the left lung back to the heart?\n" +
                       "   - A) Right Pulmonary Artery\n" +
                       "   - B) Left Pulmonary Artery\n" +
                       "   - C) Left Pulmonary Vein\n" +
                       "   - D) Superior Vena Cava\n");
        answers.Add(3); // Correct: Left Pulmonary Vein

        GenerateRandomQuestion();
    }

    private void GenerateRandomQuestion() {
        // Check if all questions have been asked
        if (_askedQuestions.Count == stringList.Count) {
            questionText.text = "Quiz Completed! Well done!";
            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);
            option3.gameObject.SetActive(false);
            option4.gameObject.SetActive(false);
            return;
        }

        // Generate a random index that hasn't been asked
        do {
            _currentQuestion = UnityEngine.Random.Range(0, stringList.Count);
        } while (_askedQuestions.Contains(_currentQuestion));

        // Add the current question to the set of asked questions
        _askedQuestions.Add(_currentQuestion);

        // Display the random question
        questionText.text = stringList[_currentQuestion];
    }

    public void GetUserAnswer(int answer) {
        if (answer == answers[_currentQuestion]) {
            StartCoroutine(ChangeQuestion(true));
        } else {
            StartCoroutine(ChangeQuestion(false));
        }
    }

    IEnumerator ChangeQuestion(bool isCorrect) {
        option1.interactable = false;
        option2.interactable = false;
        option3.interactable = false;
        option4.interactable = false;
        if (isCorrect) {
            _score++;
            scoreText.text = "Score: " + _score;
        }
        questionText.text = isCorrect ? "Correct Answer" : "Wrong Answer";

        yield return new WaitForSeconds(4f);

        GenerateRandomQuestion();

        option1.interactable = true;
        option2.interactable = true;
        option3.interactable = true;
        option4.interactable = true;
    }
}
