using System.Text;

// Калинин Павел 23.10.2022 
// Знакомство с языками программирования (семинары)
// Урок 8. Как не нужно писать код. Часть 2
// Домашняя работа

bool isRepeat = true; 
string s = "";
string taskName = "";

void FillArray(int[,] ar, int aMin, int aMax) {
    Random random = new Random();
    for(int i=0; i<ar.GetLength(0); i++)
        for(int j=0; j<ar.GetLength(1); j++)
            ar[i,j] = random.Next(aMin, aMax);
}
void PrintArray(int[,] ar) {
    if(ar == null || ar.GetLength(0)==0) {
        Console.WriteLine("\t Массив пустой.");
        return;
    }    
    for(int i=0; i<ar.GetLength(0); i++) {
        for(int j=0; j<ar.GetLength(1); j++)
            Console.Write($"{ar[i,j]} ");
        Console.WriteLine();
    }    
}

int[,] ar = null;

/*

taskName = "Задание  №54. Задайте двумерный массив."
          +" Напишите программу, которая упорядочит"
          +" по убыванию элементы каждой строки двумерного массива.";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите количество Строк двумерного массива: ");
    int qtyRow = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Столбцов двумерного массива: ");
    int qtyCol = int.Parse(Console.ReadLine() ?? "0");
    ar = new int[qtyRow,qtyCol];
    FillArray(ar, 0,10);    
    Console.WriteLine("Двумерный массив задан:");
    PrintArray(ar);
    for(int i=0; i<ar.GetLength(0); i++) 
        SortRowArray(ar, i);
    Console.WriteLine("Ответ:");
    PrintArray(ar);
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

void SortRowArray(int[,] ar, int aRow) {
    int len = ar.GetLength(1);
    int temp;
    bool isMove = true;
    while(isMove) {
        isMove = false;
        for(int j=0, i=aRow; j<len-1; j++) {
            if(ar[i,j]>ar[i,j+1]) {
                temp = ar[i,j];
                ar[i,j] = ar[i,j+1];
                ar[i,j+1] = temp;
                if(!isMove) isMove = true;
            }
        }
    }        
}

taskName = "Задание  №56. Задайте прямоугольный двумерный массив."
          +" Напишите программу, которая будет находить строку"
          +" с наименьшей суммой элементов.";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите количество Строк двумерного массива: ");
    int qtyRow = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Столбцов двумерного массива: ");
    int qtyCol = int.Parse(Console.ReadLine() ?? "0");
    ar = new int[qtyRow,qtyCol];
    FillArray(ar, 0,10);    
    Console.WriteLine("Двумерный массив задан:");
    PrintArray(ar);
    int currSum; 
    int indexMinSumRow = 0;
    int minSum = FindSumRowArray(ar, 0);
    for(int i=1; i<ar.GetLength(0); i++) {
        currSum = FindSumRowArray(ar, i);
        if(minSum > currSum) {
            minSum = currSum;
            indexMinSumRow = i;
        }    
    }    
    Console.WriteLine("Ответ:");
    Console.WriteLine($"Строка {indexMinSumRow} содержит элементы с наименьшей суммой.");
    PrintRowArray(ar, indexMinSumRow);
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

int FindSumRowArray(int[,] ar, int aRow) {
    int len = ar.GetLength(1);
    int sum = 0;
    for(int j=0; j<len; j++) 
        sum += ar[aRow,j];
    return sum;
}

void PrintRowArray(int[,] ar, int aRow) {
    for(int j=0; j<ar.GetLength(1); j++)
        Console.Write($"{ar[aRow,j]} ");
    Console.WriteLine();
}


taskName = "Задание №58. Задайте две матрицы. "
          +" Напишите программу, которая будет находить"
          +" произведение двух матриц.\n"
          +"Задание №1. Найти произведение двух матриц.";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите количество Строк первой матрицы: ");
    int qtyRow1 = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Столбцов первой матрицы: ");
    int qtyCol1 = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Строк второй матрицы: ");
    int qtyRow2 = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Столбцов второй матрицы: ");
    int qtyCol2 = int.Parse(Console.ReadLine() ?? "0");
    if(qtyCol1 == qtyRow2) {
        int[,] ar1 = new int[qtyRow1,qtyCol1];
        int[,] ar2 = new int[qtyRow2,qtyCol2];
        FillArray(ar1, 0,5);    
        FillArray(ar2, 0,5);    
        Console.WriteLine("Матрицы заданы:");
        Console.WriteLine("\t первая матрица:");
        PrintArray(ar1);
        Console.WriteLine("\t вторая матрица:");
        PrintArray(ar2);
        Console.WriteLine("Ответ:");
        PrintArray(ProductOfMatrices(ar1, ar2));
    } else Console.WriteLine("Неправильные размерности матриц.");
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

int[,] ProductOfMatrices(int[,] aAr1, int[,] aAr2) {
    int qtyRow = aAr1.GetLength(0);
    int qtyCol = aAr2.GetLength(1);
    int[,] ar = new int[qtyRow,aAr2.GetLength(1)];
    for(int i=0; i<qtyRow; i++)
        for(int j=0; j<qtyCol; j++)
            ar[i,j] = 0;
    int qtyInternal = aAr1.GetLength(1);
    for(int i=0; i<qtyRow; i++)
        for(int j=0; j<qtyCol; j++)
            for(int k=0; k<qtyInternal; k++)
                ar[i,j] += aAr1[i,k] * aAr2[k,j];
    return ar;    
}



taskName = "Задание №2. В двумерном массиве целых чисел."
          +" Удалить строку и столбец, на пересечении которых"
          +" расположен наименьший элемент.";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите количество Строк двумерного массива: ");
    int qtyRow = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество Столбцов двумерного массива: ");
    int qtyCol = int.Parse(Console.ReadLine() ?? "0");
    ar = new int[qtyRow,qtyCol];
    FillArray(ar, 0,5);    
    Console.WriteLine("Двумерный массив задан:");
    PrintArray(ar);
    int min = FindMinElementOfArray(ar);
    Console.WriteLine($"Минимальное значение равно: {min}.");
    int[] arRows = new int[qtyRow];
    int[] arCols = new int[qtyCol];
    for(int i=0; i<qtyRow; i++) arRows[i] = 0;
    for(int i=0; i<qtyCol; i++) arCols[i] = 0;
    FindRowsAndColsForDelete(ar, min, arRows, arCols);
//    Console.Write("Строки  для удаления: "); for(int i=0; i<qtyRow; i++) Console.Write(arRows[i]+" ");  Console.WriteLine("");
//    Console.Write("Столбцы для удаления: "); for(int i=0; i<qtyCol; i++) Console.Write(arCols[i]+" ");  Console.WriteLine("");
    int[,] arResult = CopyArrayWithoutRowsCols(ar, arRows, arCols);
    Console.WriteLine("Ответ:");
    PrintArray(arResult);
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

int FindMinElementOfArray(int[,] ar) {
    int qtyRow = ar.GetLength(0);
    int qtyCol = ar.GetLength(1);
    int indexRow = 0;
    int indexCol = 0;
    int min = ar[indexRow,indexCol];
    for(int i=0; i<qtyRow; i++)
        for(int j=0; j<qtyCol; j++)
            if(min > ar[i,j]) 
                min = ar[i,j];
    return min;
}

void FindRowsAndColsForDelete(int[,] ar, int min, int[] arRows, int[] arCols) {
    int qtyRow = ar.GetLength(0);
    int qtyCol = ar.GetLength(1);
    for(int i=0; i<qtyRow; i++)
        for(int j=0; j<qtyCol; j++)
            if(min == ar[i,j]) {
                arRows[i] = 1;
                arCols[j] = 1;
            }
}

int[,] CopyArrayWithoutRowsCols(int[,] ar, int[] arRows, int[] arCols) {
    int qtyRow = ar.GetLength(0);
    int qtyCol = ar.GetLength(1);
    int deletedRows = 0, deletedCols = 0;
    for(int i=0; i<qtyRow; i++) if(arRows[i]==1) deletedRows++;
    if(deletedRows >= qtyRow) return null;
    for(int i=0; i<qtyCol; i++) if(arCols[i]==1) deletedCols++;
    if(deletedCols >= qtyCol) return null;
    int[,] arResult = new int[qtyRow-deletedRows,qtyCol-deletedCols];
    int r=0, c=0;
    for(int i=0; i<qtyRow; i++)
        if(arRows[i] == 0) {
            for(int j=0; j<qtyCol; j++)
                if(arCols[j] == 0) 
                    arResult[r,c++] = ar[i,j];
            r++; c=0;
        }            
    return arResult;                
}



taskName = "Задание №60. Сформируйте трёхмерный массив"
          +" из неповторяющихся двузначных чисел. "
          +" Напишите программу, которая будет построчно выводить массив,"
          +" добавляя индексы каждого элемента.\n"
          +"Задание №3. Сформировать трехмерный массив не повторяющимися двузначными числами"
          +" показать его построчно на экран выводя индексы соответствующего элемента";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите размерность трёхмерного массива (в формате x y z): ");
    s = Console.ReadLine() ?? "0";
    string[] ss = s.Split(" ");
    int dimension0 = int.Parse(ss[0]);
    int dimension1 = int.Parse(ss[1]);
    int dimension2 = int.Parse(ss[2]);
    Console.WriteLine("Ответ:");
    int[,,] arIII = new int[dimension0,dimension1,dimension2];
    int count = 10;
    for(int i=0; i<dimension0; i++)
        for(int j=0; j<dimension1; j++)
            for(int k=0; k<dimension2; k++) {
                arIII[i,j,k] = count++;
                Console.WriteLine($"({i},{j},{k}) = {arIII[i,j,k]}");
            }    
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

*/


taskName = "Задание №4. Показать треугольник Паскаля."
          +" Сделать вывод в виде равнобедренного треугольника.";
isRepeat = true;
while(isRepeat) {
    Console.WriteLine("-----------------------------------\n\r"+taskName);
    Console.Write("Введите размерность треугольника Паскаля: ");
    int dimension = int.Parse(Console.ReadLine() ?? "0");
    ar = new int[dimension,dimension];
    Console.WriteLine("Ответ:");
    // заполнить единицами первый столбец и диагональ
    for(int i=0; i<dimension; i++) {
        ar[i,0]=1;
        ar[i,i]=1;
    }    
    // заполнить половину массива суммами
    for(int i=2; i<dimension; i++)
        for(int j=1; j<i; j++)
            ar[i,j] = ar[i-1,j-1] + ar[i-1,j];
//    PrintArray(ar);  Console.WriteLine("");
    PrintHalfTriangle(ar);
    Console.WriteLine("");
    Console.Write("----\n\rВыполнить задание еще раз? (0-нет, 1-да):");
    s = Console.ReadLine() ?? "0";
    isRepeat = s != "0";
}    

void PrintHalfTriangle(int[,] ar) {
    if(ar == null || ar.GetLength(0)==0) {
        Console.WriteLine("\t Массив пустой.");
        return;
    }
    int qtyRow = ar.GetLength(0);
    // смещение с помощью табуляций
    int shift = qtyRow-1;
    string tabs = "";
    for(int i=0; i<shift; i++) tabs += "\t";

    for(int i=0; i<qtyRow; i++) {
        Console.Write($"{tabs.Substring(i)}");
        for(int j=0; j<=i; j++)
            Console.Write($"{ar[i,j]} \t\t");
        Console.WriteLine("\n");
    }    
}



/*

Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07

*/





