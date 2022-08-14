using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher
{
    private string _question;
    private Logger _logger;

    public Teacher(string question, Logger logger)
    {
        _question = question;
        _logger = logger;
    }

    public void AskPupil(Pupil pupil)
    {
        _logger.Say("Учитель", _question);

        string answer = pupil.Answer(_question);

        if (answer == string.Empty)
        {
            _logger.Say("Учитель", "Неверно");
        }
        else
        {
            _logger.Say("Учитель", "Верно");
        }
    }
}
