﻿using System;

public static class Exceptions
{
    public static void Exception(Exception ex)
    {
        Menu.Instance.OnError();
        ShowText.Instance.OnError(ex.Message);
    }
}