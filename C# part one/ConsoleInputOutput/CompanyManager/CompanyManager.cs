using System;

class CompanyManager
{
static void Main(string[] args)
{
    string companyName;
    string companyAddress;
    string companyPhone;
    string companyFax;
    string managerFirstName;
    string managerLastName;

    Console.Write("Please input the company name: ");
    companyName = Console.ReadLine();
    Console.Write("Please input the company address: ");
    companyAddress = Console.ReadLine();
    Console.Write("Please input the company phone number: ");
    companyPhone = Console.ReadLine();
    Console.Write("Please input the company fax number: ");
    companyFax = Console.ReadLine();
    Console.Write("Please input the manager's first name: ");
    managerFirstName = Console.ReadLine();
    Console.Write("Please input the manager's first name: ");
    managerLastName = Console.ReadLine();

    Console.WriteLine("Company: {0} \n\rAddress: {1} \n\rPhone number: {2} " + 
        "\n\rFax Number: {3}\n\rManager's first name {4} \n\rManager's last name: {5}",
        companyName, companyAddress, companyPhone, companyFax, managerFirstName,
        managerLastName);
}
}
