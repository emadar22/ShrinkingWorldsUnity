using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

public class PrintOutPut : MonoBehaviour
{
    public int num;
    void Start()
    {
      //  GetOutput();
      //main();
      CalculateNumberType();
    }
   
    
    //  For Finding Most Right Num
    void GetOutput()
    {
        print("Enter A Number: ");
        print("Find Percentage: "+ num);
        int digit = num % 10;
        print("Most Right Digit For Number Is:  %d    "+digit);
    }

 public int basic_salary, items_sold, items_broken, groos_salery;
        int bonus = 0;
    void main()
    {
        print("enter the basic salary: ");
        print("%d,  "+basic_salary);
        print("enter the number of items sold:");
        print("%d,"+items_sold);
        print("Enter The Number Of Itemns Broken: ");
        print("%d  "+items_broken);
        if (items_sold > 100 && items_broken == 0)
        {
            bonus = 10000;
        }
        groos_salery = basic_salary + bonus;
        print("Gross Salary:  %d  "+groos_salery);

    }



    void CalculateNumberType()
    {
        if(num%2==0)
        {
            print("Value Is Even");
        }
        else
        {
            print("Value Is Odd");
        }
    }
}
