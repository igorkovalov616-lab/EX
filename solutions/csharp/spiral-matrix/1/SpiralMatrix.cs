using System;

public static class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];

        int top = 0, bottom = size - 1;
        int left = 0, right = size - 1;
        int value = 1;

        while (value <= size * size)
        {
            // left → right
            for (int i = left; i <= right; i++)
                matrix[top, i] = value++;
            top++;

            // top ↓ bottom
            for (int i = top; i <= bottom; i++)
                matrix[i, right] = value++;
            right--;

            // right ← left
            for (int i = right; i >= left; i--)
                matrix[bottom, i] = value++;
            bottom--;

            // bottom ↑ top
            for (int i = bottom; i >= top; i--)
                matrix[i, left] = value++;
            left++;
        }

        return matrix;
    }
}
