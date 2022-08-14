using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pupil 
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public bool HandUp { get; private set; }
    private Bag _bag;

    private string _answer;
    private string _question;
    private Logger _logger;

    public Pupil(string name, int age, string question, string answer, Logger logger)
    {
        _bag = new Bag(new string[] { "Тетрадь", "Учебник", "Пенал" });
        Name = name;
        Age = age;
        _question = question;
        _answer = answer;
        _logger = logger;
    }

    public void EnterClass(string[] requiredItems)
    {
        bool isAble = _bag.CheckReady(requiredItems);

        if (isAble)
        {
            _logger.Say(Name, "ученик вошёл в класс");
        }
        else
        {
            _logger.Say(Name, "ученик забыл что-то дома");
        }
    }

    public void ExitClass()
    {
        _logger.Say(Name, "ученик вернулся домой");
    }

    public string Answer(string question)
    {
        if (question == _question)
        {
            _logger.Say(Name, _answer);
            return _answer;
        }

        _logger.Say(Name, "не знаю...");
        return string.Empty;
    }

    public void Prepare()
    {
        HandUp = Random.Range(0, 2) == 1;
    }

}
