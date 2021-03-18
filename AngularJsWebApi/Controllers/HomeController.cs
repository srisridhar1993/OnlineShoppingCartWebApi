using AngularJsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJsWebApi.Controllers
{
    public class HomeController : Controller,ITest,ITest2
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            MyMethod();
            return View();
        }
        public void CountCharacterOccurrence()
        {
            string result = string.Empty;
            string str = "geeksforgeeks";
            while (str.Length > 0)
            {

                int count = 0;
                result += str[0] + ":";
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[0] == str[i])
                    {
                        count++;
                    }
                }
                result += count + ",";
                str = str.Replace(str[0].ToString(), string.Empty);
            }
        }
        public void ArrayBubbleShort()
        {
            int[] number = { 89, 76, 45, 92, 67, 12, 99, 12, 45, 12, 45, 92 };
            bool flag = true;
            int temp;
            int numLength = number.Length;

            //sorting an array  
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (number[j + 1] < number[j])
                    {
                        temp = number[j];
                        number[j] = number[j + 1];
                        number[j + 1] = temp;
                        flag = true;
                    }
                }
            }
            string result = string.Empty;
            //Sorted array  
            foreach (int num in number)
            {
                result += num + ",";
            }
        }
        public string MyMethod()
        {
            string s = FirstCharToUpper("ajay_kumar_yadav");
            s = s.Replace("_", "");
            return s;
        }

        public static string FirstCharToUpper(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.  
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.  
            // ... Uppercase the lowercase letters following spaces.  
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == '_')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

    }
}
