using System;
using System.Collections;
using System.Collections.Generic;

public static class ActionExtension
{
    public static void SafeInvoke(this Action self)
    {
        if (self != null)
        {
            self();
        }
    }


    public static void SafeInvoke<T>(this Action<T> self, T param)
    {
        if (self != null)
        {
            self(param);
        }
    }
}