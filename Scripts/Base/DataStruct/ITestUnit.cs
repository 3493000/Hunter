//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;

namespace Hunter
{
    public interface ITestUnit
    {
        void StartTest();
    }

    public class BaseTestUnit : ITestUnit
    {
        public virtual void StartTest()
        {

        }

        protected void WriteBegin(string title)
        {
            Console.WriteLine(string.Format("*********** {0} Begin **********", title));
        }

        protected void WriteEnd(string title)
        {
            Console.WriteLine(string.Format("*********** {0} End **********", title));
        }

        protected void Write(string msg)
        {
            Console.Write(msg);
        }

        protected void WriteLine(string msg, params object[] args)
        {
            Console.WriteLine(string.Format(msg, args));
        }
    }
}


