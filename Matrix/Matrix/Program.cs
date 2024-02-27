// Definir la matriz 4x4
int[] stepsArray = new int[] { 1, 2, -1, 1, 0, 1, 2, -1, -1, -2 };
Dictionary<string, int[]> steps = new Dictionary<string, int[]>();



// Mostrar la matriz en la consola
Console.WriteLine("Matriz 4X4 inicial: ");
int matrixSize = 4;
var matriz = createMatrix(matrixSize, 0, 0);
PrintMatrix(matriz);

//obtenemos los pasos del arreglo de pasos: agrupando cada paso en dos items del arreglo
// cada paso se debe mover asi: primer numero en el eje X(columna) y segundo en el eje Y(row).
for (int i = 0; i < stepsArray.Length; i += 2)
{
    string key = "step " + ((i / 2) + 1);
    int[] array = new int[2];
    array[0] = stepsArray[i];// primero es la columna
    array[1] = stepsArray[i + 1]; // segundo es la fila
    steps[key] = array;
}
//Recorremos los pasos para mover la X en le matriz, posicion inicial 0,0
foreach (var step in steps)
{
    Console.WriteLine($"{step.Key} : column: {step.Value[0]}, row: {step.Value[1]}");
    int newColumn = step.Value[0];
    int newRow = step.Value[1];

    matriz = MoveXInMatrix(matriz, newRow, newColumn, matrixSize - 1);
    Console.WriteLine("New position of X: ");
    PrintMatrix(matriz);
}
Console.WriteLine("Final position of X: ");
PrintMatrix(matriz);

// Método para imprimir la matriz
static void PrintMatrix(char[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

//Método para mover la X en la matriz
static char[,] MoveXInMatrix(char[,] matrix, int row, int column, int maxPosition)
{
    // positivo en column es derecha
    // negativo en column es izquierda 
    // positivo en row es abajo
    // negativo en row es arriba
    // Paso 1: (1, 2)
    // Paso 2: (-1, 1)
    // Paso 3: (0, 1)
    // Paso 4: (2, -1)
    // Paso 5: (-1, -2)
    int[] coordinatesX = findCharacter(matrix, 'X');
    int minPosition = 0;

    if (column >= 0)
    {
        coordinatesX[0] += column;
        if (coordinatesX[0] > maxPosition)
        {
            coordinatesX[0] = maxPosition;
        }
    }
    else
    {
        coordinatesX[0] += column;
        if (coordinatesX[0] < minPosition)
        {
            coordinatesX[0] = minPosition;
        }
    }

    if (row >= 0)
    {
        coordinatesX[1] += row;
        if (coordinatesX[1] > maxPosition)
        {
            coordinatesX[1] = maxPosition;
        }
    }
    else
    {
        coordinatesX[1] += row;
        if (coordinatesX[1] < minPosition)
        {
            coordinatesX[1] = minPosition;
        }
    }

    var matriz = createMatrix(4, coordinatesX[1], coordinatesX[0]);
    return matriz;
}

static char[,] createMatrix(int size, int rowPosition, int columnPosition)
{
    char[,] matriz = new char[size, size];

    for (int fila = 0; fila < matriz.GetLength(0); fila++)
    {
        for (int columna = 0; columna < matriz.GetLength(1); columna++)
        {
            if (fila == rowPosition && columna == columnPosition)
            {
                matriz[fila, columna] = 'X';
            }
            else
            {
                matriz[fila, columna] = 'O';
            }

        }
    }
    return matriz;
}
static int[] findCharacter(char[,] matrix, char target)
{
    int row = -1;
    int column = -1;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == target)
            {
                row = i;
                column = j;
                return new int[] { column, row };
            }
        }
    }
    return new int[] { column, row };
}