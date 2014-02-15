/* Create a class Person with two fields – name and age. Age can be left unspecified 
 * (may contain null value. Override ToString() to display the information of a person
 * and if age is not specified – to say so. Write a program to test this functionality. */

using System;

namespace PersonTest
{
    class PersonTest
    {
        static void Main()
        {
            Person somePerson = new Person("Gosho Gankov");
            Person otherPerson = new Person("Pesho", 10);
            Console.WriteLine(somePerson);
            Console.WriteLine(otherPerson);
        }
    }
}
