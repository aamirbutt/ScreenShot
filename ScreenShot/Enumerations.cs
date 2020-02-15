using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Screenshot
{
    public enum CurrentState
    {
        STATE_IDLE,
        STATE_EDITING,
        STATE_CAPTURINGWND,
        STATE_CAPTURINGSCREEN,
        STATE_READYFOREDITING
    }

    public enum EditState
    {
        NONE,
        CROP,
        PEN,
        CIRCLE,
        RECTANGLE,
        ARROW,
        LINE,
        TEXT,
        SELECTION
    }

    public enum TaskBarLocation { TOP, BOTTOM, LEFT, RIGHT }

}
