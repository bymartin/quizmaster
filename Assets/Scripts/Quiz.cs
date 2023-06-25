using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    private void Start()
    {
        DisplayQuestion();
        // GetNextQuestion();
    }

    private void GetNextQuestion() {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index) {
        int correctIndex = question.GetCorrectAnswerIndex();
        Image buttonImage;
        if (index == correctIndex) {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        } else {
            questionText.text = "Sorry, the correct answer was:\n" + question.GetAnswer(correctIndex);
            buttonImage = answerButtons[correctIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        SetButtonState(false);
    }

    private void SetButtonState(bool state) {
        for (int i = 0; i < answerButtons.Length; i++) {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void SetDefaultButtonSprites() {
        for (int i = 0; i < answerButtons.Length; i++) {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }



}
