using Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK;
using Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK.Attributes;
using System;


namespace DanishBankHoliday
{
    [Action(Id = "IsBankHoliday")]  // All classes representing actions must have an Action attribute specified above
    public class IsDanishBankHolidays : ActionBase // Likewise, all classes representing actions must be public and inherit from the ActionBase class
    {
        // Input and output parameters for our action are specified as classic C# properties. However, they must have an attribute above that indicates whether they are input or output parameters
        [InputArgument]
        public DateTime DateToCheck { get; set; }

        [OutputArgument]
        public bool IsBankHoliday { get; set; }

        public override void Execute(ActionContext context) // In this method, we will write the actual code we want to execute. It should be defined this way
        {

            // I've cheated a bit from home and have made the code to calculate Easter Sunday in advance - and yes, you're right. I asked ChatGPT to write the code for me.
            int a = DateToCheck.Year % 19;
            int b = DateToCheck.Year / 100;
            int c = DateToCheck.Year % 100;
            int d = (int)(b / 4);
            int e = b % 4;
            int f = (int)((b + 8) / 25);
            int g = (int)((b - f + 1) / 3);
            int h = (19 * a + b - d - g + 15) % 30;
            int i = (int)(c / 4);
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (int)((a + 11 * h + 22 * l) / 451);
            int month = (int)((h + l - 7 * m + 114) / 31);
            int day = ((h + l - 7 * m + 114) % 31 + 1);
            DateTime easter = new DateTime(DateToCheck.Year, month, day);

            // Now we can check if the given day is a public holiday. I've cheated a bit again and defined the list of holidays from home
            if (DateToCheck.Day == 01 && DateToCheck.Month == 01   // New Year's Day
                || DateToCheck.Day == 24 && DateToCheck.Month == 12   // Christmas Eve
                || DateToCheck.Day == 25 && DateToCheck.Month == 12   // Christmas Day
                || DateToCheck.Day == 26 && DateToCheck.Month == 12   // Boxing Day
                || DateToCheck.Day == 31 && DateToCheck.Month == 12   // New Year's Eve
                || DateToCheck == easter                       // Easter Sunday
                || DateToCheck == easter.AddDays(-3)           // Maundy Thursday
                || DateToCheck == easter.AddDays(-2)           // Good Friday
                || DateToCheck == easter.AddDays(+1)           // Easter Monday
                || DateToCheck == easter.AddDays(+39)          // Ascension Day
                || DateToCheck == easter.AddDays(+40)          // Bank holiday after Ascension Day
                || DateToCheck == easter.AddDays(+49)          // Pentecost
                || DateToCheck == easter.AddDays(+50)          // Whit Monday
                || DateToCheck.Day == 05 && DateToCheck.Month == 06 // Constitution Day
                )
            {
                IsBankHoliday = true;
            }
            else
            {
                IsBankHoliday = false;
            }
        }

    }
}
