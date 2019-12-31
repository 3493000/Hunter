using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public enum PanelEventLogType
    {
        None,
        Single,
        LifeCircleSingle,
        Repeat,
        Mix
    }

    public interface IPanelEventLogger
    {
        void LogPanelOpen(string name, PanelEventLogType eventType);
        void LogPanelClose(string name, PanelEventLogType eventType);
    }
}
