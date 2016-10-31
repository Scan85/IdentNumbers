using System.Collections.Generic;

namespace IdentNumbers.Contracts
{
    public interface IMatrixComparer
    {
        string CompareMatrixes(List<char[]> matrix, int x, int y, MatrixChar matrixChar);

        List<int> GetMatrixSize(List<char[]> matrix);
    }
}