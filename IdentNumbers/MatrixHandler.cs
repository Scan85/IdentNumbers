using IdentNumbers.Contracts;
using System;
using System.Collections.Generic;

namespace IdentNumbers
{
    public class MatrixHandler : IMatrixHandler
    {
        private readonly IMatrixGenerator _matrixGenerator;
        private readonly IMatrixComparer _matrixComparer;

        public MatrixHandler() : this(new MatrixGenerator(), new MatrixComparer())
        {
        }

        public MatrixHandler(IMatrixGenerator matrixGenerator, IMatrixComparer matrixComparer)
        {
            if (matrixGenerator == null) throw new NullReferenceException("MatrixGenerator missing");
            _matrixGenerator = matrixGenerator;

            if (matrixComparer == null) throw new NullReferenceException("MatrixComparer missing");
            _matrixComparer = matrixComparer;
        }

        public string HandleMatrix(string path)
        {
            string resultString = "";

            var matrix = _matrixGenerator.GetMatrix(path);

            var matrixChars = _matrixGenerator.GetDefinedMatrixChars();

            var matrixListToCompare = new List<List<char[]>>();

            for (var i = 0; i < matrix.Count; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    foreach (var matrixChar in matrixChars)
                    {
                        resultString += _matrixComparer.CompareMatrixes(matrix, j, i, matrixChar);
                    }
                }
            }

            return resultString;
        }
    }
}