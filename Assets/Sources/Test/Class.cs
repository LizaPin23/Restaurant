using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class
{
    private Teacher _teacher;
    private Pupil[] _pupils;
    private string[] _requiredItems;

    public Class(Teacher teacher, Pupil[] pupils, string[] requiredItems)
    {
        _teacher = teacher;
        _pupils = pupils;
        _requiredItems = requiredItems;
    }

    public void StartLesson()
    {
        for (int i = 0; i < _pupils.Length; i++)
        {
            _pupils[i].EnterClass(_requiredItems);
            _teacher.AskPupil(_pupils[i]);
            _pupils[i].ExitClass();
        }
    }
}
