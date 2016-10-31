using System.Collections.Generic;

namespace IdentNumbers.Contracts
{
    public interface IReaderWrapper
    {
        List<string> ReadFile(string path);
    }
}