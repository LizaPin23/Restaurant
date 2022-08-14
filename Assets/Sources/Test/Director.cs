using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] private string _question;
    [SerializeField] private string[] _requiredItems;
    [SerializeField] private Logger _logger;

    private void Start()
    {
        Teacher teacher = new Teacher(_question, _logger);

        Pupil[] pupils =
        {
            new Pupil("Саша", 11, "2х2", "4", _logger),
            new Pupil("Аня", 10, "Корень слова бежать", "беж", _logger), 
        };

        Class lesson = new Class(teacher, pupils, _requiredItems);

        lesson.StartLesson();
    }
}
