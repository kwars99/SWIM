using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Services
{
    public interface IDisplayInfo
    {
        int GetDisplayWidth();
        int GetDisplayHeight();
        int GetDisplayDpi();
    }
}
