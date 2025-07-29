using System.Collections.Generic;
using FightSystem.Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTask", menuName = "Quest/Task")]
public class Task : ScriptableObject
{
    enum State 
    { 
        KillSomebody, 
        TalkToSomebody,
        VisitPlace
    }

    [SerializeField] State currenTask;
}
public class KillSomebody
{
    public Enemy enemyToKill;
    public int killCount;

    public void CompleteTask()
    {
        //������� � Enemy ��� Death ����� �������� ���������� �������
        if (killCount == 0)
        {
            OnTaskCompleted();
        }
    }

    public void FailTask()
    {
        //������� � Enemy ��� Death ����� �������� ���������� �������
        if (killCount == 0 /*&& ����� �� ������� ��� �� ������ � ���-��*/)
        {
            OnTaskFailed();
        }
    }

    public void OnTaskCompleted()
    {
        //������ ������� � ��
    }

    public void OnTaskFailed()
    {
        //������ �������
    }
}

public class TalkingToSomebody
{
    public ITalkable NPS;
}
