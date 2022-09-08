using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static bool IsThereItemInList<T>(this List<T> list) => list.Count != 0;

    public static T RemoveLast<T>(this List<T> myList)
    {
        T temp = myList[myList.Count - 1];
        myList.Remove(temp);
        return temp;
    }

}
