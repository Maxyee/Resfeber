public int GetYear(DateTime presentYear, DateTime uploadYear)
{
    int result = presentYear.Year - uploadYear.Year;
    return result;
}



public int GetMonth(DateTime presentMonth, DateTime uploadedMonth)
{
    int result = presentMonth.Month - uploadedMonth.Month;

    int calcuResult = Math.Abs(result);

    if (result < 0)
    {
        int month = 12;
        result = month - calcuResult;
        return result;
    }



    return result;
}


public int GetDay(DateTime presentDay, DateTime uploadedDay)
{
    int result = presentDay.Day - uploadedDay.Day;

    int calcuResult = Math.Abs(result);

    if (result < 0)
    {
        if (uploadedDay.Month == 4 || uploadedDay.Month == 6 || uploadedDay.Month == 9 ||
            uploadedDay.Month == 11)
        {
            int days = 30;


            result = days - calcuResult;
            return result;
        }
        else if (uploadedDay.Month == 1 || uploadedDay.Month == 3 || uploadedDay.Month == 5 ||
            uploadedDay.Month == 7 || uploadedDay.Month == 8 || uploadedDay.Month == 10 ||
            uploadedDay.Month == 12)
        {
            int days = 31;


            result = days - calcuResult;
            return result;
        }
        else if (((uploadedDay.Year % 4 == 0) && (uploadedDay.Year % 100 != 0)) || (uploadedDay.Year % 400 == 0) && (uploadedDay.Month == 2))
        {
            int days = 29;


            result = days - calcuResult;
            return result;
        }
        else
        {
            int days = 28;


            result = days - calcuResult;
            return result;
        }

    }

    return result;

}



public int GetHours(int presentHour, int uploadedHour)
{
    int result = presentHour - uploadedHour;
    return result;
}


public int GetMinute(int presentMinute, int uploadedMinute)
{
    int result = presentMinute - uploadedMinute;
    return result;
}


public string GetEventTime(DateTime presentDateTime, DateTime uploadedDateTime)
{

    string demoTime = "updating time..";

    int resultYear = GetYear(presentDateTime, uploadedDateTime);


    if (resultYear > 1)
    {
        if (presentDateTime.Month >= uploadedDateTime.Month)
        {
            return resultYear + "y";
        }
        else
        {
            resultYear = resultYear - 1;
            return resultYear + "y";
        }
        //return resultYear + "y";
    }
    else if (resultYear == 1 && presentDateTime.Month >= uploadedDateTime.Month)
    {
        return "1y";
        
    }
    else if (resultYear <= 1)
    {
        int resultMonth = GetMonth(presentDateTime, uploadedDateTime);
        if (resultMonth > 1)
        {

            if (presentDateTime.Day >= uploadedDateTime.Day)
            {
                return resultMonth + "mo";
            }
            else
            {
                resultMonth = resultMonth - 1;
                return resultMonth + "mo";
            }
            
        }
        else if (resultMonth <= 1)
        {

            int resultDay = GetDay(presentDateTime, uploadedDateTime);
            if (resultDay == 0 && presentDateTime.Month != uploadedDateTime.Month)
            {
                return "1mo";
            }
            else if (resultMonth == 1 && presentDateTime.Day >= uploadedDateTime.Day)
            {
                return "1mo";
            }
            else if (resultDay > 1)
            {
                if (resultDay == 7)
                {
                    if (presentDateTime.Hour >= uploadedDateTime.Hour && presentDateTime.Minute >= uploadedDateTime.Minute)
                    {
                        return "1w";
                    }
                    else
                    {
                        return resultDay + "d";
                    }
                }
                else if (resultDay == 14)
                {
                    if (presentDateTime.Hour >= uploadedDateTime.Hour && presentDateTime.Minute >= uploadedDateTime.Minute)
                    {
                        return "2w";
                    }
                    else
                    {
                        return "1w";
                    }
                }
                else if (resultDay == 21)
                {
                    if (presentDateTime.Hour >= uploadedDateTime.Hour && presentDateTime.Minute >= uploadedDateTime.Minute)
                    {
                        return "3w";
                    }
                    else
                    {
                        return "2w";
                    }
                }
                else if (resultDay == 28)
                {
                    if (presentDateTime.Hour >= uploadedDateTime.Hour && presentDateTime.Minute >= uploadedDateTime.Minute)
                    {
                        return "4w";
                    }
                    else
                    {
                        return "3w";
                    }
                }
                else if (resultDay >= 8 && resultDay <= 13)
                {
                    return "1w";
                }
                else if (resultDay >= 15 && resultDay <= 20)
                {
                    return "2w";
                }
                else if (resultDay >= 22 && resultDay <= 27)
                {
                    return "3w";
                }
                else if (resultDay >= 29)
                {
                    return "4w";
                }
                else if (presentDateTime.Hour >= uploadedDateTime.Hour)
                {
                    return resultDay + "d";
                }
                else
                {
                    resultDay = resultDay - 1;
                    return resultDay + "d";
                }

            }
            else if (resultDay <= 1)
            {
                int resultHours = GetHours(presentDateTime.Hour, uploadedDateTime.Hour);
                if (resultHours == 0 && presentDateTime.Day != uploadedDateTime.Day)
                {
                    return "1d";
                }
                else if (resultDay == 1 && presentDateTime.Hour >= uploadedDateTime.Hour)
                {
                    return "1d";
                }
                else if (resultHours > 1)
                {
                    if (presentDateTime.Minute >= uploadedDateTime.Minute)
                    {
                        return resultHours + "h";
                    }
                    else
                    {
                        resultHours = resultHours - 1;
                        return resultHours + "h";
                    }
                }
                else if (resultHours < 0)
                {
                    int calcuResult = Math.Abs(resultHours);
                    calcuResult = 24 - calcuResult;
                    return calcuResult + "h";
                }
                else if (resultHours <= 1)
                {
                    int resultMinute = GetMinute(presentDateTime.Minute, uploadedDateTime.Minute);
                    int positiveMinute = Math.Abs(resultMinute);

                    if (resultMinute == 0 && presentDateTime.Hour != uploadedDateTime.Hour)
                    {
                        return "1h";
                    }
                    else if (resultHours == 1 && presentDateTime.Minute >= uploadedDateTime.Minute)
                    {
                        return "1h";
                    }
                    else if (resultHours == 1 && positiveMinute < 60)
                    {
                        int calRes = 60 - positiveMinute;
                        return calRes + "m";
                    }
                    else if (resultMinute > 1)
                    {
                        return resultMinute + "m";
                    }
                    else if (resultMinute < 0)
                    {
                        int calcuResult = Math.Abs(resultMinute);
                        calcuResult = 60 - calcuResult;
                        return calcuResult + "m";
                    }
                    else
                    {
                        return "Just now";
                    }
                }
            }

        }

    }

    return demoTime;
}