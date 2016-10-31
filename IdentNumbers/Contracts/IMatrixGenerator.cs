using System.Collections.Generic;

namespace IdentNumbers.Contracts
{
    public interface IMatrixGenerator
    {
        List<char[]> GetMatrix(string path);

        List<MatrixChar> GetDefinedMatrixChars();
    }
}