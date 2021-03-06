using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCondition : Condition
{
    public enum eCompare
    {
        Equal,
        Greater,
        Greater_Equal,
        Less,
        Less_Equal
    }

    public eCompare Compare { get; set; } = eCompare.Equal;
    public int compareInt
    {
        set
        {
            Compare = (eCompare)value;
        }
    }

    public float value { get; set; }
    public string valueString
    {
        set
        {
            float.TryParse(value, out float v);
            this.value = v;
        }
    }
    public float parameter { get; set; }

    public override bool IsTrue()
    {
        bool isTrue = false;

        switch (Compare)
        {
            case eCompare.Equal:
                isTrue = (parameter == value);
                break;
            case eCompare.Greater:
                isTrue = (parameter > value);
                break;
            case eCompare.Greater_Equal:
                isTrue = (parameter >= value);
                break;
            case eCompare.Less:
                isTrue = (parameter < value);
                break;
            case eCompare.Less_Equal:
                isTrue = (parameter <= value);
                break;
            default:
                break;
        }

        return isTrue;
    }
}
