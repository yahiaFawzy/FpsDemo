using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectableViewElement<T> : ViewElement<T>, ISelectable where T : class
{
    public abstract void Select();
    public abstract void UnSelect();
}
