using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SWIM.Services
{
    public interface IPrintService
    {
        void Print(Stream inputStream, string fileName);
    }
}
