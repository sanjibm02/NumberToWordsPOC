using System;
using System.Text;

namespace NumberToWords
{
  public class NumberToWordConversion
  {
    private static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Enter a Number to convert to words");
        Console.WriteLine((object) new NumberToWordConversion().DisplayOutput(Console.ReadLine()));
      }
      catch (Exception ex)
      {
        throw ex;
      }
      Console.ReadKey();
    }

    public StringBuilder DisplayOutput(string number)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string str = "";
      double doublenumber;
      if (!double.TryParse(number, out doublenumber))
      {
        stringBuilder.Append("Please enter valid number");
        return stringBuilder;
      }
      try
      {
        if (number.Contains("-"))
        {
          str = "Minus ";
          number = number.Substring(1, number.Length - 1);
        }
        if (number == "0")
        {
          Console.WriteLine("The number in format is \nZero Only");
        }
        else
        {
          StringBuilder words = this.ConvertToWords(number);
          if (words != null)
            stringBuilder.AppendFormat("The number in currency format is:{0}", (object) (str + (object) words));
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return stringBuilder;
    }

    private StringBuilder ConvertToWords(string numb)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder Number = new StringBuilder(numb);
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      try
      {
        if (numb.IndexOf(".") > 0)
        {
          Console.WriteLine("Only whole number is allowed");
          return (StringBuilder) null;
        }
        stringBuilder1.AppendFormat("{0} {1}", (object) this.ConvertWholeNumber(Number).Trim(), (object) stringBuilder3);
      }
      catch
      {
      }
      return stringBuilder1;
    }

    private string ConvertWholeNumber(StringBuilder Number)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        bool flag1 = false;
        bool flag2 = false;
        if (Convert.ToDouble(Number.ToString()) > 0.0)
        {
          flag1 = Number.ToString().StartsWith("0");
          int length = Number.Length;
          int num = 0;
          string str = "";
          switch (length)
          {
            case 1:
              stringBuilder = this.ones(Number);
              flag2 = true;
              break;
            case 2:
              stringBuilder = this.tens(Number);
              flag2 = true;
              break;
            case 3:
              num = length % 3 + 1;
              str = " Hundred ";
              break;
            case 4:
            case 5:
            case 6:
              num = length % 4 + 1;
              str = " Thousand ";
              break;
            case 7:
            case 8:
            case 9:
              num = length % 7 + 1;
              str = " Million ";
              break;
            case 10:
            case 11:
            case 12:
              num = length % 10 + 1;
              str = " Billion ";
              break;
            default:
              flag2 = true;
              break;
          }
          if (!flag2)
          {
            if (Number.ToString().Substring(0, num) != "0" && Number.ToString().Substring(num) != "0")
            {
              try
              {
                stringBuilder.Append(this.ConvertWholeNumber(new StringBuilder(Number.ToString().Substring(0, num))) + str + this.ConvertWholeNumber(new StringBuilder(Number.ToString().Substring(num))));
              }
              catch
              {
              }
            }
            else
              stringBuilder.Append(this.ConvertWholeNumber(new StringBuilder(Number.ToString().Substring(0, num))) + this.ConvertWholeNumber(new StringBuilder(Number.ToString().Substring(num))));
          }
          if (stringBuilder.ToString().Trim().Equals(str.Trim()))
            stringBuilder.Clear();
        }
      }
      catch
      {
      }
      return stringBuilder.ToString().Trim();
    }

    private StringBuilder tens(StringBuilder number)
    {
      StringBuilder stringBuilder = new StringBuilder("");
      try
      {
        int int32 = Convert.ToInt32(number.ToString());
        switch (int32)
        {
          case 10:
            stringBuilder.Append("Ten");
            break;
          case 11:
            stringBuilder.Append("Eleven");
            break;
          case 12:
            stringBuilder.Append("Twelve");
            break;
          case 13:
            stringBuilder.Append("Thirteen");
            break;
          case 14:
            stringBuilder.Append("Fourteen");
            break;
          case 15:
            stringBuilder.Append("Fifteen");
            break;
          case 16:
            stringBuilder.Append("Sixteen");
            break;
          case 17:
            stringBuilder.Append("Seventeen");
            break;
          case 18:
            stringBuilder.Append("Eighteen");
            break;
          case 19:
            stringBuilder.Append("Nineteen");
            break;
          case 20:
            stringBuilder.Append("Twenty");
            break;
          case 30:
            stringBuilder.Append("Thirty");
            break;
          case 40:
            stringBuilder.Append("Fourty");
            break;
          case 50:
            stringBuilder.Append("Fifty");
            break;
          case 60:
            stringBuilder.Append("Sixty");
            break;
          case 70:
            stringBuilder.Append("Seventy");
            break;
          case 80:
            stringBuilder.Append("Eighty");
            break;
          case 90:
            stringBuilder.Append("Ninety");
            break;
          default:
            if (int32 > 0)
            {
              stringBuilder.Append(this.tens(new StringBuilder(number.ToString().Substring(0, 1) + "0")).ToString() + " " + (object) this.ones(new StringBuilder(number.ToString().Substring(1))));
              break;
            }
            break;
        }
      }
      catch (Exception ex)
      {
        throw new InvalidCastException(ex.Message);
      }
      return stringBuilder;
    }

    private StringBuilder ones(StringBuilder number)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        switch (Convert.ToInt32(number.ToString()))
        {
          case 1:
            stringBuilder.Append("One");
            break;
          case 2:
            stringBuilder.Append("Two");
            break;
          case 3:
            stringBuilder.Append("Three");
            break;
          case 4:
            stringBuilder.Append("Four");
            break;
          case 5:
            stringBuilder.Append("Five");
            break;
          case 6:
            stringBuilder.Append("Six");
            break;
          case 7:
            stringBuilder.Append("Seven");
            break;
          case 8:
            stringBuilder.Append("Eight");
            break;
          case 9:
            stringBuilder.Append("Nine");
            break;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return stringBuilder;
    }
  }
}
