using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObjectiveType
{
    Simple,
    AmountToReach
}

public class Objective
{
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public ObjectiveType Type { get; private set; }
    public int AmountToReach { get; private set; }
    public int CurrentAmount { get; private set; }

    public Objective(string description, ObjectiveType type, int amountToReach = 0)
    {
        Description = description;
        IsCompleted = false;
        Type = type;
        AmountToReach = amountToReach;
        CurrentAmount = 0;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public void UpdateProgress(int amount)
    {
        if (Type == ObjectiveType.AmountToReach)
        {
            CurrentAmount += amount;
            if (CurrentAmount >= AmountToReach)
            {
                MarkAsCompleted();
            }
        }
    }
}
