using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Namespace per la gestione delle scene

[System.Serializable]
public class Question
{
    public string questionText; // Testo della domanda
    public string[] answers;    // Array delle risposte
    public int[] clinicalValues; // Clinical values corresponding to the answers
}

public class SofiScript : MonoBehaviour
{
    public Question[] questions;       // Lista delle domande e risposte
    private int currentQuestionIndex;  // Indice della domanda corrente

    public TextMeshProUGUI questionTextUI; // UI componente per il testo della domanda
    public Button[] answerButtons;        // Array di bottoni per le risposte

    void Start()
    {
        Debug.Log("start");
        currentQuestionIndex = 0;
        HideAllQuestionsAndAnswers(); // Nascondi tutto all'inizio
        ShowQuestion();               // Mostra la prima domanda
    }

    // Nasconde tutto il testo delle domande e i bottoni delle risposte
    private void HideAllQuestionsAndAnswers()
    {
        questionTextUI.gameObject.SetActive(false); // Nascondi il testo della domanda

        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    // Your existing ShowQuestion method remains unchanged
    public void ShowQuestion()
    {
        Debug.Log("ShowQuestion() triggered.");
        Debug.Log(currentQuestionIndex);
        HideAllQuestionsAndAnswers();

        if (currentQuestionIndex < questions.Length)
        {
            Question currentQuestion = questions[currentQuestionIndex];

            Debug.Log(currentQuestion.questionText);

            questionTextUI.text = currentQuestion.questionText;
            questionTextUI.gameObject.SetActive(true);

            if (currentQuestion.answers.Length == 4)
            {
                Debug.Log("domanda da 4");
                for (int j = 0; j < 4; j++)
                {
                    if (j < currentQuestion.answers.Length)
                    {
                        answerButtons[j].gameObject.SetActive(true); // Mostra i primi 4 pulsanti
                        answerButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[j];
                    }
                }
            }
            else
            {
                Debug.Log("domanda da 5");
                for (int j = 4; j < 9; j++)
                {
                    int answerIndex = j - 4;
                    if (answerIndex < currentQuestion.answers.Length)
                    {
                        answerButtons[j].gameObject.SetActive(true); // Mostra i pulsanti dal 4 all'8
                        answerButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[answerIndex];    
                    }
                }
            }
        }
        else
        {
            Debug.Log("No more questions! Assigning persona...");
            MyGameManager.Instance.AssignPersona(); // Calcola e assegna la persona
            LoadNextScene(); // Carica la versione del gioco associata
        }
    }

    // Called when an answer button is clicked
    public void OnAnswerSelected(int index)
    {
        Debug.Log("Selected answer: " + questions[currentQuestionIndex].answers[index]);

        // Retrieve the clinical value for the selected answer
        int clinicalValue = (questions[currentQuestionIndex].clinicalValues != null &&
                         questions[currentQuestionIndex].clinicalValues.Length > index)
                        ? questions[currentQuestionIndex].clinicalValues[index]
                        : index;

        // Handle specific questions differently (e.g., asrs_12 and asrs_56)
        switch (currentQuestionIndex)
        {
            case 0: // GAD-1
                MyGameManager.Instance.gadData["gad_1"] = clinicalValue;
                break;
            case 1: // GAD-2
                MyGameManager.Instance.gadData["gad_2"] = clinicalValue;
                break;
            case 2: // ASRS-12 (special case: double the clinical value)
                MyGameManager.Instance.adhdData["asrs_12"] = clinicalValue * 2; // Double the value
                break;
            case 3: // ASRS-3
                MyGameManager.Instance.adhdData["asrs_3"] = clinicalValue;
                break;
            case 4: // ASRS-4
                MyGameManager.Instance.adhdData["asrs_4"] = clinicalValue;
                break;
            case 5: // ASRS-56 (special case: double the clinical value)
                MyGameManager.Instance.adhdData["asrs_56"] = clinicalValue * 2; // Double the value
                break;
        }
        // Log clinical data after updating
        MyGameManager.Instance.LogClinicalData();

        currentQuestionIndex++;
        ShowQuestion(); // Show the next question
    }
    private void LoadNextScene()
    {   MyGameManager.Instance.LogAssignedPersona();
        // Transition to the next scene(eg NoSleepPlayer)
        SceneManager.LoadScene("NoSleepPlayer");
    }


}