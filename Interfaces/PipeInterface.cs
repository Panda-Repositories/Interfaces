using System;
using System.IO;
using System.IO.Pipes;

namespace OmegaX.Interfaces
{
    public partial class PipeInterface
    {
        public string PipeName;
        public int Timeout;

        public void SendData(string Data, Uri Source = null, bool IsUri = false)
        {
            if (PipeName is null || PipeName == "") throw new Exception("A pipename cannot be empty.");
            if (Data is null) return;
            if (Source is null) return;

            //check pipefirst

            try
            {
                using (var ClientStream = new NamedPipeClientStream(".", PipeName, PipeDirection.Out))
                {
                    ClientStream.Connect(Timeout);

                    using (var Stream = new StreamWriter(ClientStream))
                    {
                        if (Data is not null && IsUri != true) Stream.Write(Data);
                        else if (Source is not null && IsUri != false) Stream.Write(WebInterface.DownloadString(Source));

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
