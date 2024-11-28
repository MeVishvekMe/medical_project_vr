using System.Collections.Generic;
using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartQuiz2Script : MonoBehaviour {
    public TextMeshProUGUI questionText;
    public List<string> stringList = new List<string>();
    public List<int> answers = new List<int>();

    private HashSet<int> _askedQuestions = new HashSet<int>();
    private int _currentQuestion;

    private int _score = 0;
    public TextMeshProUGUI scoreText;
    void Start() {
        // Hardcode the questions into the list
        stringList.Add("Which vessel emerges directly from the left ventricle, carrying oxygen-rich blood to the entire body?");
        answers.Add(6);
        
        stringList.Add("Identify the blood vessel that transports deoxygenated blood from the upper body to the heart. It forms from the union of the left and right brachiocephalic veins.");
        answers.Add(11);
        
        stringList.Add("This chamber receives oxygen-poor blood from the body. Can you find it?");
        answers.Add(7);
        
        stringList.Add("Locate the valve that prevents backflow of blood when the right ventricle contracts.");
        answers.Add(19);
        
        stringList.Add("Where would you find the thickest muscle wall, needed to pump blood through the systemic circulation?");
        answers.Add(9);
        
        stringList.Add("Point to the artery that splits to deliver oxygen-poor blood to the lungs for oxygenation.");
        answers.Add(10);
        
        stringList.Add("Can you identify the vessel that carries oxygen-rich blood from the left lung back to the heart?");
        answers.Add(12);
        
        stringList.Add("Which structure divides the left and right chambers of the heart to prevent mixing of oxygenated and deoxygenated blood?");
        answers.Add(21);
        
        stringList.Add("Identify the chamber that pumps deoxygenated blood into the pulmonary arteries for oxygenation in the lungs.");
        answers.Add(8);
        
        stringList.Add("Find the chamber that acts as a reservoir for blood returning from the lungs.");
        answers.Add(17);
        
        GenerateRandomQuestion();
    }

    private void GenerateRandomQuestion() {
        // Check if all questions have been asked
        if (_askedQuestions.Count == stringList.Count) {
            questionText.text = "Quiz Completed! Well done!";
            
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
        
        if (isCorrect) {
            _score++;
            scoreText.text = "Score: " + _score;
        }
        questionText.text = isCorrect ? "Correct Answer" : "Wrong Answer";

        yield return new WaitForSeconds(4f);

        GenerateRandomQuestion();

        
    }
}
