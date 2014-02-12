// Extend the program to support also subtraction and multiplication of polynomials.

using System;

class ExtendPolynomialOperations
{
    static void Main()
    {
        GetUserInput();
    }

    static void GetUserInput()
    {
        // Get input from the user and print it as a polynomial
        decimal[] firstPolynom = InputPolynomial();
        PrintPolynomial(firstPolynom);
        decimal[] secondPolynom = InputPolynomial();
        PrintPolynomial(secondPolynom);
        
        // Give the user a choose of operation on both polynomials
        Console.WriteLine("Please choose operation input: ");
        Console.WriteLine("(a) is for Addition");
        Console.WriteLine("(b) is for Subtraction");
        Console.WriteLine("(c) is for Multiplication");

        string choice = Console.ReadLine();
        
        switch(choice)
        {
            case "a":
            case "A":
                PrintPolynomial(SumPolynoms(firstPolynom, secondPolynom));
                break;
            case "b":
            case "B":
                PrintPolynomial(SubstractPolynoms(firstPolynom, secondPolynom));
                break;
            case "c":
            case "C":
                PrintPolynomial(MultiplyPolinomials(firstPolynom, secondPolynom));
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    static void PrintPolynomial(decimal[] array)
    {
        // this will print the Polynomial
        Array.Reverse(array);
        Console.Write("The result is: ");
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                Console.Write("{0}", array[i]);
            }
            else if (i == 1)
            {
                // If the number is positive put the plus sign, otherwise the number is already printed with its sign.
                Console.Write("{0}X {1} ", array[i], (array[i - 1] < 0 ? ' ' : '+'));
            }
            else
            {
                Console.Write("{0}X^{1} {2} ", array[i], i, (array[i - 1] < 0 ? ' ' : '+'));
            }
        }
        Console.WriteLine();
    }

    static decimal[] InputPolynomial()
    {
        // This takes care of the input and validation
        Console.Write("Please input the degree of the polynomial: ");
        int degree = int.Parse(Console.ReadLine());
        decimal[] polynom = new decimal[degree + 1];

        for (int i = 0; i <= degree; i++)
        {
            if (i == degree)
            {
                Console.Write("Please input the last coefficient: ");
            }
            else
            {
                Console.Write("Please input the next coefficient: ");
            }
            bool valid = decimal.TryParse(Console.ReadLine(), out polynom[i]);
            if (!valid)
            {
                // If the input is invalid then return one cycle 
                i--;
            }
        }
        return polynom;
    }

    static decimal[] SumPolynoms(decimal[] a, decimal[] b)
    {
        int biggerArray;
        int smallerArray;

        if (a.Length > b.Length)
        {
            biggerArray = a.Length;
            smallerArray = b.Length;
        }
        else
        {
            biggerArray = b.Length;
            smallerArray = a.Length;
        }
        // This determines the length of the bigger array
        decimal[] sum = new decimal[biggerArray];


        for (int digit = 0; digit < biggerArray; digit++)
        {
            if (digit < smallerArray) // Sum the common digits of both arrays.
            {
                sum[digit] = (a[digit] + b[digit]);
            }
            // Add the portion of the bigger array that's left into the new array
            else if (a.Length > b.Length)
            {
                sum[digit] = (a[digit]);
            }
            else if (a.Length < b.Length)
            {
                sum[digit] = (b[digit]);
            }
        }
        Array.Reverse(sum);
        return sum;
    }

    static decimal[] SubstractPolynoms(decimal[] a, decimal[] b)
    {
        // I change the sign of the smaller array and than sum the two
        if (a.Length > b.Length)
        {
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = -b[i];
            }
        }
        else
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = -a[i];
            }
        }
        decimal[] result = SumPolynoms(a, b);
        return result;
    }

    static decimal[] MultiplyPolinomials(decimal[] a, decimal[] b)
    {
        // Multiply the polynomials
        decimal[] result = new decimal[a.Length + b.Length];

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                int position = i + j;
                result[position] = result[position] + (a[i] * b[j]);
            }
        }
        return result;
    }

}