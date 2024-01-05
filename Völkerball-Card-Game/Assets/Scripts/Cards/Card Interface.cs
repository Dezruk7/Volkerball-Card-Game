using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    bool IsUsable();
    void StartCountdown(float duration);
}
