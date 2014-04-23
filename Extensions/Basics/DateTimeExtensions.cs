using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class DateTimeExtensions
    {
        #region Day

        /// <summary>
        /// <para>DE: Gibt den Endzeitpunkt des Tages wieder
        ///     (die letzte millisekunde für die letzte Stunde des übergeben <see cref="DateTime"/>).</para>
        /// <para>EN: Returns the very end of the given day 
        ///     (the last millisecond of the last hour for the given <see cref="DateTime"/>).</para>
        /// </summary>
        /// <param name="date">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// <para>DE: Gibt den Startzeitpunkt des Tages wieder
        ///     (die erste millisekunden des übergebenen <see cref="DateTime"/>).</para>
        /// <para>EN: Returns the Start of the given day 
        ///     (the first millisecond of the given <see cref="DateTime"/>).</para>
        /// </summary>
        /// <param name="date">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime BeginningOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// <para>DE: Gibt <see cref="DateTime"/> plus 24 Stunden zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> increased by 24 hours ie Next Day.</para>
        /// </summary>
        /// <param name="start">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime NextDay(this DateTime start)
        {
            return start + 1.Days();
        }

        /// <summary>
        /// <para>DE: Gibt <see cref="DateTime"/> minus 24 Stunden zurück.</para>
        /// <para>En: Returns <see cref="DateTime"/> decreased by 24h period ie Previous Day.</para>
        /// </summary>
        /// <param name="start">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime PreviousDay(this DateTime start)
        {
            return start - 1.Days();
        }

        /// <summary>
        /// <para>DE: Gibt das Datum des nächsten <see cref="DayOfWeek"/> zurück.</para>
        /// <para>EN: Returns first next occurrence of specified <see cref="DayOfWeek"/>.</para>
        /// </summary>
        /// <param name="start">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="day">The target day of week.</param>
        public static DateTime Next(this DateTime start, DayOfWeek day)
        {
            do
            {
                start = start.NextDay();
            }
            while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// <para>DE: Gibt das Datum des letzten <see cref="DayOfWeek"/> zurück.</para>
        /// <para>EN: Returns first previous occurrence of specified <see cref="DayOfWeek"/>.</para>
        /// </summary>
        /// <param name="start">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="day">The target day of week.</param>
        public static DateTime Previous(this DateTime start, DayOfWeek day)
        {
            do
            {
                start = start.PreviousDay();
            }
            while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// <para>DE: Fügt die angegeben Tage in Arbeitstagen hinzu.</para>
        /// <para>EN: Adds the given number of business days to the <see cref="DateTime"/>.</para>
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime AddWorkingDays(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while
                (
                    current.DayOfWeek == DayOfWeek.Saturday
                  ||current.DayOfWeek == DayOfWeek.Sunday
                );
            }
            return current;
        }

        /// <summary>
        /// <para>DE: Zieht die angegeben Tage in Arbeitstagen ab.</para>
        /// <para>EN: Subtracts the given number of business days to the <see cref="DateTime"/>.</para>
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be subtracted.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime SubtractWorkingDays(this DateTime current, int days)
        {
            return AddWorkingDays(current, -days);
        }

        /// <summary>
        /// <para>DE: Fügt die angegeben Tage in Arbeitstagen hinzu und überspringt dabei alle in NRW gültigen Feiertage.</para>
        /// <para>EN: Adds the given number of business days to the <see cref="DateTime"/> for German State of NRW.</para>
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime AddWorkingDays_NRW(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while
                (
                     current.DayOfWeek == DayOfWeek.Saturday
                  || current.DayOfWeek == DayOfWeek.Sunday
                  || current.IsHoliday()
                );
            }
            return current;
        }

        /// <summary>
        /// <para>DE: Zieht die angegeben Tage in Arbeitstagen ab und überspringt dabei alle in NRW gültigen Feiertage.</para>
        /// <para>EN: Substracts the given number of business days from the <see cref="DateTime"/> for German State of NRW.</para>
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime SubstractWorkingDays_NRW(this DateTime current, int days)
        {
            return AddWorkingDays_NRW(current, -days);
        }

        /// <summary>
        /// <para>DE: Fügt die angegeben Tage in Bankarbeitstagen hinzu und überspringt dabei alle in Deutschland gültigen Bankfeiertage.</para>
        /// <para>EN: Adds the given number of bankbusiness days to the <see cref="DateTime"/> for Germany.</para>
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime AddBankBusinessDays_Germany(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while
                (
                     current.DayOfWeek == DayOfWeek.Saturday
                  || current.DayOfWeek == DayOfWeek.Sunday
                  || current.IsBankHoliday()
                );
            }
            return current;
        }

        /// <summary>
        /// <para>DE: Zieht die angegeben Tage in Bankarbeitstagen ab und überspringt dabei alle in Deutschland gültigen Bankfeiertage.</para>
        /// <para>EN: Substracts the given number of bankbusiness days from the <see cref="DateTime"/> for Germany.</para>
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime SubstractBusinessDays_Germany(this DateTime current, int days)
        {
            return AddBankBusinessDays_Germany(current, -days);
        }

        #region Helperfunctions for Workingday_NRW and BankBusinessDay Calculation
        /// <summary>
        /// <para>DE: Gibt zurück ob das angegebene Datum ein Feiertag ist.</para>
        /// <para>EN: Returns true if the given datetime is a holiday.</para>
        /// </summary>
        /// <param name="_date">The Date to be checked</param>
        /// <returns>true = holiday | fale = no holiday</returns>
        public static bool IsHoliday(this DateTime _date)
        {
            bool isHoliday = false;

            // Datum zerlegen und für den Test eines Festen Feiertages zusammenbauen
            String testDate = (_date.Day.ToString() + "/" + _date.Month.ToString());

            switch (testDate)
            {
                //Neujahr
                case "1/1":
                    isHoliday = true;
                    break;

                //Tag der Arbeit
                case "1/5":
                    isHoliday = true;
                    break;

                //Mariae Himmelfahrt
                case "15/8":
                    isHoliday = true;
                    break;

                //Tag der dt. Einheit
                case "3/10":
                    isHoliday = true;
                    break;

                //Allerheiligen
                case "1/11":
                    isHoliday = true;
                    break;

                //1. Weihnachtstag
                case "25/12":
                    isHoliday = true;
                    break;

                //2. Weihnachtstag
                case "26/12":
                    isHoliday = true;
                    break;

                //Beweglicher Feiertag
                default:
                    isHoliday = IsMovableHoliday(_date.Date);
                    break;
            }

            return isHoliday;
        }

        /// <summary>
        /// <para>DE: Gibt zurück ob das angegebene Datum ein beweglicher Feiertag ist.</para>
        /// <para>EN: Returns true if the given datetime is a moveable holiday.</para>
        /// </summary>
        /// <param name="_date">The Date to be checked</param>
        /// <returns>true = moveable holiday | fale = no movable holiday</returns>
        private static bool IsMovableHoliday(DateTime _date)
        {
            int Jahr = _date.Year;
            DateTime Ostersonntag = GetOstersonntag(Jahr);

            //OsterSonntag
            if (_date == Ostersonntag.AddDays(0))
            {
                return true;
            }
            //Karfreitag
            if (_date == Ostersonntag.AddDays(-2))
            {
                return true;
            }
            //Ostermontag
            if (_date == Ostersonntag.AddDays(1))
            {
                return true;
            }
            //Christi Himmelfahrt
            if (_date == Ostersonntag.AddDays(39))
            {
                return true;
            }
            //Pfingstsonntag
            if (_date == Ostersonntag.AddDays(49))
            {
                return true;
            }
            //Pfingstmontag
            if (_date == Ostersonntag.AddDays(50))
            {
                return true;
            }
            //Fronleichnam
            if (_date == Ostersonntag.AddDays(60))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// <para>DE: Gibt zurück ob das angegebene Datum ein Feiertag ist an dem die Bank nicht arbeitet.</para>
        /// <para>EN: Returns true if the given datetime is a bank holiday.</para>
        /// </summary>
        /// <param name="_date">The Date to be checked</param>
        /// <returns>true = holiday | fale = no holiday</returns>
        public static bool IsBankHoliday(this DateTime _date)
        {
            bool isHoliday = false;

            // Datum zerlegen und für den Test eines Festen Feiertages zusammenbauen
            String testDate = (_date.Day.ToString() + "/" + _date.Month.ToString());

            switch (testDate)
            {
                //Neujahr
                case "1/1":
                    isHoliday = true;
                    break;

                //Tag der Arbeit
                case "1/5":
                    isHoliday = true;
                    break;

                //1. Weihnachtstag
                case "25/12":
                    isHoliday = true;
                    break;

                //2. Weihnachtstag
                case "26/12":
                    isHoliday = true;
                    break;

                //Beweglicher Feiertag
                default:
                    isHoliday = IsMovableHoliday(_date.Date);
                    break;
            }

            return isHoliday;
        }

        /// <summary>
        /// <para>DE: Gibt zurück ob das angegebene Datum ein beweglicher Feiertag ist an dem die Bank nicht arbeitet.</para>
        /// <para>EN: Returns true if the given datetime is a moveable bank holiday.</para>
        /// </summary>
        /// <param name="_date">The Date to be checked</param>
        /// <returns>true = moveable holiday | fale = no movable holiday</returns>
        private static bool IsMovableBankHoliday(DateTime _date)
        {
            int Jahr = _date.Year;
            DateTime Ostersonntag = GetOstersonntag(Jahr);

            //OsterSonntag
            if (_date == Ostersonntag.AddDays(0))
            {
                return true;
            }
            //Karfreitag
            if (_date == Ostersonntag.AddDays(-2))
            {
                return true;
            }
            //Ostermontag
            if (_date == Ostersonntag.AddDays(1))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// <para>DE: Gibt day Datum des Ostersonntags für das angegebene Jahr zurück.</para>
        /// <para>EN: Returns the Datetime of Ostersonntag for the given Year.</para>
        /// </summary>
        /// <param name="_date">The Date to be checked</param>
        /// <returns>Datetime = Ostersonntag</returns>
        private static DateTime GetOstersonntag(int jahr)
        {
            int c;
            int i;
            int j;
            int k;
            int l;
            int n;
            int OsterTag;
            int OsterMonat;

            c = jahr / 100;
            n = jahr - 19 * ((int)(jahr / 19));
            k = (c - 17) / 25;
            i = c - c / 4 - ((int)(c - k) / 3) + 19 * n + 15;
            i = i - 30 * ((int)(i / 30));
            i = i - (i / 28) * ((int)(1 - (i / 28)) * ((int)(29 / (i + 1))) * ((int)(21 - n) / 11));
            j = jahr + ((int)jahr / 4) + i + 2 - c + ((int)c / 4);
            j = j - 7 * ((int)(j / 7));
            l = i - j;

            OsterMonat = 3 + ((int)(l + 40) / 44);
            OsterTag = l + 28 - 31 * ((int)OsterMonat / 4);

            return Convert.ToDateTime(OsterTag.ToString() + "." + OsterMonat + "." + jahr);
        }
         #endregion

        #endregion

        #region Week

        /// <summary>
        /// <para>DE: Das übergebene <see cref="DateTime"/> plus 7 Tage.</para>
        /// <para>EN: Increases supplied <see cref="DateTime"/> for 7 days ie returns the Next Week.</para>
        /// </summary>
        /// <param name="start">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime WeekAfter(this DateTime start)
        {
            return start + 1.Weeks();
        }

        /// <summary>
        /// <para>DE: Das übergebene <see cref="DateTime"/> minus 7 Tage.</para>
        /// <para>EN: Decreases supplied <see cref="DateTime"/> for 7 days ie returns the Previous Week.</para>
        /// </summary>
        /// <param name="start">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime WeekEarlier(this DateTime start)
        {
            return start - 1.Weeks();
        }

        /// <summary>
        /// <para>DE: Gibt das Startdatum der übergeben Woche zurück.</para>
        /// <para>EN: Gets the Startdate of the specified Week as dateTime.</para>
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime date)
        {
            int DaysToSubtract = (int)date.DayOfWeek;
            DateTime dt =
                DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// <para>DE: Gibt das Enddatum der übergeben Woche zurück.</para>
        /// <para>EN: Gets the Enddate of the specified Week as dateTime.</para>
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime date)
        {
            DateTime dt = StartOfWeek(date).AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        #endregion

        #region Month

        /// <summary>
        /// <para>DE: Gibt das Startdatum des gegeben Monats zurück.</para>
        /// <para>EN: Returns the startdate of the given moth.</para>
        /// </summary>
        /// <param name="_dateTime"></param>
        /// <returns></returns>
        public static DateTime StartOfMonth(this DateTime _dateTime)
        {
            return StartOfMonth((Month)_dateTime.Month, DateTime.Now.Year);
        }

        /// <summary>
        /// <para>DE: Gibt das Enddatum des gegeben Monats zurück.</para>
        /// <para>EN: Returns the enddate of the given moth.</para>
        /// </summary>
        /// <param name="_dateTime"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime _dateTime)
        {
            return EndOfMonth((Month)_dateTime.Month, DateTime.Now.Year);
        }

        /// <summary>
        /// <para>DE: Gibt das Startdatum des gegeben Monats zurück.</para>
        /// <para>EN: Returns the startdate of the given moth.</para>
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        public static DateTime StartOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// <para>DE: Gibt das Enddatum des gegeben Monats zurück.</para>
        /// <para>EN: Returns the enddate of the given moth.</para>
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month, DateTime.DaysInMonth(Year, (int)Month), 23, 59, 59, 999);
        }

        #endregion

        #region Year

        /// <summary>
        /// <para>DE: Gibt den/die selbe (Day, Month, Hour, Minute, Second etc)
        ///     aus dem nächsten Kalenderjahr zurück.
        ///     Wenn der Tag im nächsten Jahr/Monat nicht existiert werden die
        ///     Differenztage zum letzen Tag des Monats im nächsten Jahr hinzugefügt.</para>
        /// <para>EN: Returns the same date (same Day, Month, Hour, Minute, Second etc) 
        ///     in the next calendar year.
        ///     If that day does not exist in next year in same month, 
        ///     number of missing days is added to the last day in same month next year.</para>
        /// </summary>
        /// <param name="start">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime NextYear(this DateTime start)
        {
            var nextYear = start.Year + 1;
            var numberOfDaysInSameMonthNextYear = DateTime.DaysInMonth(nextYear, start.Month);

            if (numberOfDaysInSameMonthNextYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthNextYear;
                var dateTime = new DateTime(nextYear, start.Month, numberOfDaysInSameMonthNextYear, start.Hour, start.Minute, start.Second, start.Millisecond);
                return dateTime + differenceInDays.Days();
            }

            return new DateTime(nextYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond);
        }

        /// <summary>
        /// <para>DE: Gibt den/die selbe (Day, Month, Hour, Minute, Second etc)
        ///     aus dem letzten Kalenderjahr zurück.
        ///     Wenn der Tag im letzten Jahr/Monat nicht existiert werden die
        ///     Differenztage zum letzen Tag des Monats im letzten Jahr hinzugefügt.</para>
        /// <para>EN: Returns the same date (same Day, Month, Hour, Minute, Second etc) 
        ///     in the previous calendar year.
        ///     If that day does not exist in previous year in same month, 
        ///     number of missing days is added to the last day in same month previous year.</para>
        /// </summary>
        /// <param name="start">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime PreviousYear(this DateTime start)
        {
            var previousYear = start.Year - 1;
            var numberOfDaysInSameMonthPreviousYear = DateTime.DaysInMonth(previousYear, start.Month);

            if (numberOfDaysInSameMonthPreviousYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthPreviousYear;
                var dateTime = new DateTime(previousYear, start.Month, numberOfDaysInSameMonthPreviousYear, start.Hour, start.Minute, start.Second, start.Millisecond);
                return dateTime + differenceInDays.Days();
            }

            return new DateTime(previousYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond);
        }

        /// <summary>
        /// <para>DE: Gibt das Startdatum des gegeben Jahrs zurück.</para>
        /// <para>EN: Returns the startdate of the given year.</para>
        /// </summary>
        /// <param name="_dateTime"></param>
        /// <returns></returns>
        public static DateTime StartOfYear(this DateTime _dateTime)
        {
            return StartOfYear(_dateTime.Year);
        }

        /// <summary>
        /// <para>DE: Gibt das Enddatum des gegeben Jahrs zurück.</para>
        /// <para>EN: Returns the enddate of the given year.</para>
        /// </summary>
        /// <param name="_dateTime"></param>
        /// <returns></returns>
        public static DateTime GetEndOfCurrentYear(this DateTime _dateTime)
        {
            return EndOfYear(_dateTime.Year);
        }

        /// <summary>
        /// <para>DE: Gibt das Startdatum des gegeben Jahrs zurück.</para>
        /// <para>EN: Returns the startdate of the given year.</para>
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public static DateTime StartOfYear(int Year)
        {
            return new DateTime(Year, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// <para>DE: Gibt das Enddatum des gegeben Jahrs zurück.</para>
        /// <para>EN: Returns the enddate of the given year.</para>
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public static DateTime EndOfYear(int Year)
        {
            return new DateTime(Year, 12,
                DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        #endregion

        #region Time

        /// <summary>
        /// <para>DE: Das übergebene <see cref="DateTime"/> plus <see cref="TimeSpan"/></para>
        /// <para>EN: Increases the <see cref="DateTime"/> object with given <see cref="TimeSpan"/> value.</para>
        /// </summary>
        /// <param name="startDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="toAdd">The timespan to add on a date.</param>
        public static DateTime IncreaseTime(this DateTime startDate, TimeSpan toAdd)
        {
            return startDate + toAdd;
        }

        /// <summary>
        /// <para>DE: Das übergebene <see cref="DateTime"/> minus <see cref="TimeSpan"/></para>
        /// <para>EN: Decreases the <see cref="DateTime"/> object with given <see cref="TimeSpan"/> value.</para>
        /// </summary>
        /// <param name="startDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="toSubtract">The timespan to suvstract on a date.</param>
        public static DateTime DecreaseTime(this DateTime startDate, TimeSpan toSubtract)
        {
            return startDate - toSubtract;
        }

        /// <summary>
        /// <para>DE: Gibt das übergebene/originale <see cref="DateTime"/> mit veränderter Stunde zurück.</para>
        /// <para>EN: Returns the original <see cref="DateTime"/> with Hour part changed to supplied hour parameter.</para>
        /// </summary>
        /// <param name="originalDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="hour">The hour to set on a date.</param>
        public static DateTime SetTime(this DateTime originalDate, int hour)
        {
            return new DateTime(
                originalDate.Year,
                originalDate.Month,
                originalDate.Day,
                hour,
                originalDate.Minute,
                originalDate.Second,
                originalDate.Millisecond
            );
        }

        /// <summary>
        /// <para>DE: Gibt das übergebene/originale <see cref="DateTime"/> mit veränderter Stunde
        ///     und Minute zurück.</para>
        /// <para>EN: Returns the original <see cref="DateTime"/> with Hour and 
        ///     Minute parts changed to supplied hour and minute parameters.</para>
        /// </summary>
        /// <param name="originalDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="hour">The hour to set on a date.</param>
        /// <param name="minute">The minute to set on a date.</param>
        public static DateTime SetTime(this DateTime originalDate, int hour, int minute)
        {
            return new DateTime(
                originalDate.Year,
                originalDate.Month,
                originalDate.Day,
                hour,
                minute,
                originalDate.Second,
                originalDate.Millisecond
            );
        }

        /// <summary>
        /// <para>DE: Gibt das übergebene/originale <see cref="DateTime"/> mit veränderter Stunde
        ///     Minute und Sekunde zurück.</para>
        /// <para>EN: Returns the original <see cref="DateTime"/> with Hour, 
        ///     Minute and Second parts changed to supplied hour, minute 
        ///     and second parameters.</para>
        /// </summary>
        /// <param name="originalDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="hour">The hour to set on a date.</param>
        /// <param name="minute">The minute to set on a date.</param>
        /// <param name="second">The second to set on a date.</param>
        public static DateTime SetTime(this DateTime originalDate, int hour, int minute, int second)
        {
            return new DateTime(
                originalDate.Year,
                originalDate.Month,
                originalDate.Day,
                hour,
                minute,
                second,
                originalDate.Millisecond
            );
        }

        /// <summary>
        /// <para>DE: Gibt das übergebene/originale <see cref="DateTime"/> mit veränderter Stunde,
        ///     Minute, Sekunde und Millisekunde zurück.</para>
        /// <para>EN: Returns the original <see cref="DateTime"/> with Hour, 
        ///     Minute, Second and Millisecond parts changed to supplied hour, 
        ///     minute, second and millisecond parameters.</para>
        /// </summary>
        /// <param name="originalDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="hour">The hour to set on a date.</param>
        /// <param name="minute">The minute to set on a date.</param>
        /// <param name="second">The second to set on a date.</param>
        /// <param name="millisecond">The millisecond to set on a date.</param>
        public static DateTime SetTime(this DateTime originalDate, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(
                originalDate.Year,
                originalDate.Month,
                originalDate.Day,
                hour,
                minute,
                second,
                millisecond
            );
        }

        /// <summary>
        /// <para>DE: Gibt das übergebene/originale <see cref="DateTime"/> mit veränderter Stunde zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Hour part.</para>
        /// </summary>
        /// <param name="originalDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="hour">The hour to set on a date.</param>
        public static DateTime SetHour(this DateTime originalDate, int hour)
        {
            return originalDate.SetTime(hour);
        }

        /// <summary>
        /// <para>DE: Gibt das übergebene/originale <see cref="DateTime"/> mit veränderter Minute zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Minute part.</para>
        /// </summary>
        /// <param name="originalDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="minute">The minute to set on a date.</param>
        public static DateTime SetMinute(this DateTime originalDate, int minute)
        {
            return originalDate.SetTime(originalDate.Hour, minute);
        }

        /// <summary>
        /// <para>DE: Gibt das übergebene/originale <see cref="DateTime"/> mit veränderter Sekunde zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Second part.</para>
        /// </summary>
        /// <param name="originalDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="second">The second to set on a date.</param>
        public static DateTime SetSecond(this DateTime originalDate, int second)
        {
            return originalDate.SetTime(originalDate.Hour, originalDate.Minute, second);
        }

        /// <summary>
        /// <para>DE: Gibt das übergebene/originale <see cref="DateTime"/> mit veränderter Millisekunde zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Millisecond part.</para>
        /// </summary>
        /// <param name="originalDate">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="millisecond">The millisecond to set on a date.</param>
        public static DateTime SetMillisecond(this DateTime originalDate, int millisecond)
        {
            return originalDate.SetTime(
                originalDate.Hour,
                originalDate.Minute,
                originalDate.Second,
                millisecond
            );
        }

        /// <summary>
        /// <para>DE: Gibt das <see cref="DateTime"/> mit veränderter Uhrzeit auf Mitternacht.
        ///     Ein Alias für die <see cref="BeginningOfDay"/> Methode.</para>
        /// <para>EN: Returns original <see cref="DateTime"/> value with time part set to 
        ///     midnight (alias for <see cref="BeginningOfDay"/> method).</para>
        /// </summary>
        /// <param name="value">The instance of the <see cref="DateTime"/> object.</param>
        public static DateTime Midnight(this DateTime value)
        {
            return value.BeginningOfDay();
        }

        /// <summary>
        /// <para>DE: Gibt das <see cref="DateTime"/> mit veränderter Uhrzeit auf die Mittagszeit (12:00:00).</para>
        /// <para>EN: Returns original <see cref="DateTime"/> value with time part set to Noon (12:00:00h).</para>
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> find Noon for.</param>
        /// <returns>A <see cref="DateTime"/> value with time part set to Noon (12:00:00h).</returns>
        public static DateTime Noon(this DateTime value)
        {
            return value.SetTime(12, 0, 0, 0);
        }

        /// <summary>
        /// <para>DE: Setzt die Uhrzeit auf(at) die gegebenen Werte.</para>
        /// <para>EN: Returns the given <see cref="DateTime"/> with hour and minutes set At given values.</para>
        /// </summary>
        /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
        /// <param name="hour">The hour to set time to.</param>
        /// <param name="minute">The minute to set time to.</param>
        /// <returns><see cref="DateTime"/> with hour and minute set to given values.</returns>
        public static DateTime At(this DateTime current, int hour, int minute)
        {
            return current.SetTime(hour, minute);
        }

        /// <summary>
        /// <para>DE: Setzt die Uhrzeit auf(at) die gegebenen Werte.</para>
        /// <para>EN: Returns the given <see cref="DateTime"/> with hour and minutes and seconds set At given values.</para>
        /// </summary>
        /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
        /// <param name="hour">The hour to set time to.</param>
        /// <param name="minute">The minute to set time to.</param>
        /// <param name="second">The second to set time to.</param>
        /// <returns><see cref="DateTime"/> with hour and minutes and seconds set to given values.</returns>
        public static DateTime At(this DateTime current, int hour, int minute, int second)
        {
            return current.SetTime(hour, minute, second);
        }

        #endregion

        #region Set Date

        /// <summary>
        /// <para>DE: Gibt das <see cref="DateTime"/> mit veränderten Jahr zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Year part.</para>
        /// </summary>
        /// <param name="value">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="year">The year to set on a date.</param>
        public static DateTime SetDate(this DateTime value, int year)
        {
            return new DateTime(
                year,
                value.Month,
                value.Day,
                value.Hour,
                value.Minute,
                value.Second,
                value.Millisecond
            );
        }

        /// <summary>
        /// <para>DE: Gibt das <see cref="DateTime"/> mit veränderten Jahr und Monat zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Year and Month part.</para>
        /// </summary>
        /// <param name="value">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="year">The year to set on a date.</param>
        /// <param name="month">The month to set on a date.</param>
        public static DateTime SetDate(this DateTime value, int year, int month)
        {
            return new DateTime(
                year,
                month,
                value.Day,
                value.Hour,
                value.Minute,
                value.Second,
                value.Millisecond
            );
        }

        /// <summary>
        /// <para>DE: Gibt das <see cref="DateTime"/> mit veränderten Jahr,Monat und Tag zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Year, Month and Day part.</para>
        /// </summary>
        /// <param name="value">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="year">The year to set on a date.</param>
        /// <param name="month">The month to set on a date.</param>
        /// <param name="day">The day to set on a date.</param>
        public static DateTime SetDate(this DateTime value, int year, int month, int day)
        {
            return new DateTime(
                year,
                month,
                day,
                value.Hour,
                value.Minute,
                value.Second,
                value.Millisecond
            );
        }

        /// <summary>
        /// <para>DE: Gibt das <see cref="DateTime"/> mit veränderten Jahr zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Year part.</para>
        /// </summary>
        /// <param name="value">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="year">The year to set on a date.</param>
        public static DateTime SetYear(this DateTime value, int year)
        {
            return value.SetDate(year);
        }

        /// <summary>
        /// <para>DE: Gibt das <see cref="DateTime"/> mit veränderten Monat zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Month part.</para>
        /// </summary>
        /// <param name="value">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="month">The month to set on a date.</param>
        public static DateTime SetMonth(this DateTime value, int month)
        {
            return value.SetDate(value.Year, month);
        }

        /// <summary>
        /// <para>DE: Gibt das <see cref="DateTime"/> mit veränderten Tag zurück.</para>
        /// <para>EN: Returns <see cref="DateTime"/> with changed Day part.</para>
        /// </summary>
        /// <param name="value">The instance of the <see cref="DateTime"/> object.</param>
        /// <param name="day">The day to set on a date.</param>
        public static DateTime SetDay(this DateTime value, int day)
        {
            return value.SetDate(value.Year, value.Month, day);
        }

        #endregion

        #region Expressions

        /// <summary>
        /// <para>DE: Prüft ob das <see cref="DateTime"/> vor dem aktuellen(current) Datum ist.</para>
        /// <para>EN: Determines whether the specified <see cref="DateTime"/> is before then current value.</para>
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="toCompareWith">Value to compare with.</param>
        /// <returns>
        /// <c>true</c> if the specified current is before; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBefore(this DateTime current, DateTime toCompareWith)
        {
            return current < toCompareWith;
        }

        /// <summary>
        /// <para>DE: Prüft ob das <see cref="DateTime"/> nach dem aktuellen(current) Datum ist.</para>
        /// <para>EN: Determines whether the specified <see cref="DateTime"/> value is After then current value.</para>
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="toCompareWith">Value to compare with.</param>
        /// <returns>
        /// <c>true</c> if the specified current is after; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAfter(this DateTime current, DateTime toCompareWith)
        {
            return current > toCompareWith;
        }

        /// <summary>
        /// <para>DE: Stell fest ob das Datum in der Zukunft liegt.</para>
        /// <para>EN: Determine if a <see cref="DateTime"/> is in the future.</para>
        /// </summary>
        /// <param name="dateTime">The date to be checked.</param>
        /// <returns><c>true</c> if <paramref name="dateTime"/> is in the future; otherwise <c>false</c>.</returns>
        public static bool IsInFuture(this DateTime dateTime)
        {
            return dateTime > DateTime.Now;
        }

        /// <summary>
        /// <para>DE: Stellt fest ob das Datum in der Vergangenheit liegt.</para>
        /// <para>EN: Determine if a <see cref="DateTime"/> is in the past.</para>
        /// </summary>
        /// <param name="dateTime">The date to be checked.</param>
        /// <returns><c>true</c> if <paramref name="dateTime"/> is in the past; otherwise <c>false</c>.</returns>
        public static bool IsInPast(this DateTime dateTime)
        {
            return dateTime < DateTime.Now;
        }

        #endregion

        #region Quaters

        /// <summary>
        /// <para>DE: Gibt das Quartal zurück</para>
        /// <para>EN: Returns the Quater</para>
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>
        public static Quarter GetQuarter(Month Month)
        {
            if (Month <= Month.March)
                // 1st Quarter = January 1 to March 31

                return Quarter.First;
            else if ((Month >= Month.April) && (Month <= Month.June))
                // 2nd Quarter = April 1 to June 30

                return Quarter.Second;
            else if ((Month >= Month.July) && (Month <= Month.September))
                // 3rd Quarter = July 1 to September 30

                return Quarter.Third;
            else // 4th Quarter = October 1 to December 31

                return Quarter.Fourth;
        }

        /// <summary>
        /// <para>DE: Gibt das Quartal zurück</para>
        /// <para>EN: Returns the Quater</para>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static Quarter GetQuarter(this DateTime dateTime)
        {
            return GetQuarter((Month)dateTime.Month);
        }


        /// <summary>
        /// <para>DE: Gibt das StartDatum des Quartals zurück</para>
        /// <para>EN: Returns the StartDate of the Quater</para>
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Qtr"></param>
        /// <returns></returns>
        public static DateTime GetStartOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)    // 1st Quarter = January 1 to March 31

                return new DateTime(Year, 1, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30

                return new DateTime(Year, 4, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30

                return new DateTime(Year, 7, 1, 0, 0, 0, 0);
            else // 4th Quarter = October 1 to December 31

                return new DateTime(Year, 10, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// <para>DE: Gibt das EndDatum des Quartals zurück</para>
        /// <para>EN: Returns the EndDate of the Quater</para>
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Qtr"></param>
        /// <returns></returns>
        public static DateTime GetEndOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)    // 1st Quarter = January 1 to March 31

                return new DateTime(Year, 3,
                        DateTime.DaysInMonth(Year, 3), 23, 59, 59, 999);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30

                return new DateTime(Year, 6,
                        DateTime.DaysInMonth(Year, 6), 23, 59, 59, 999);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30

                return new DateTime(Year, 9,
                        DateTime.DaysInMonth(Year, 9), 23, 59, 59, 999);
            else // 4th Quarter = October 1 to December 31

                return new DateTime(Year, 12,
                        DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }


        /// <summary>
        /// <para>DE: Gibt das StartDatum des Quartals zurück</para>
        /// <para>EN: Returns the StartDate of the Quater</para>
        /// </summary>
        /// <returns></returns>
        public static DateTime StartOfQuarter(this DateTime dateTime)
        {
            return GetStartOfQuarter(dateTime.Year,
                    GetQuarter((Month)dateTime.Month));
        }

        /// <summary>
        /// <para>DE: Gibt das EndDatum des Quartals zurück</para>
        /// <para>EN: Returns the EndDate of the Quater</para>
        /// </summary>
        /// <returns></returns>
        public static DateTime EndOfQuarter(this DateTime dateTime)
        {
            return GetEndOfQuarter(dateTime.Year,
                    GetQuarter((Month)dateTime.Month));
        }


        /// <summary>
        /// <para>DE: Gibt das StartDatum des letzten Quartals zurück</para>
        /// <para>EN: Returns the StartDate of last the Quater</para>
        /// </summary>
        /// <returns></returns>
        public static DateTime StartOfLastQuarter(this DateTime dateTime)
        {
            if ((Month)dateTime.Month <= Month.March)
                //go to last quarter of previous year

                return GetStartOfQuarter(dateTime.Year - 1, Quarter.Fourth);
            else //return last quarter of current year

                return GetStartOfQuarter(dateTime.Year,
                    GetQuarter((Month)dateTime.Month));
        }

        /// <summary>
        /// <para>DE: Gibt das EndDatum des letzten Quartals zurück</para>
        /// <para>EN: Returns the EndDate of last the Quater</para>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EndOfLastQuarter(this DateTime dateTime)
        {
            if ((Month)dateTime.Month <= Month.March)
                //go to last quarter of previous year

                return GetEndOfQuarter(dateTime.Year - 1, Quarter.Fourth);
            else //return last quarter of current year

                return GetEndOfQuarter(dateTime.Year,
                    GetQuarter((Month)dateTime.Month));
        }

        #endregion

        /// <summary>
        /// <para>DE: Sezt den Tag des Datums auf den ersten des Monats.</para>
        /// <para>EN: Sets the day of the <see cref="DateTime"/> to the first day in that month.</para>
        /// </summary>
        /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
        /// <returns>given <see cref="DateTime"/> with the day part set to the first day in that month.</returns>
        public static DateTime FirstDayOfMonth(this DateTime current)
        {
            return current.SetDay(1);
        }

        /// <summary>
        /// <para>DE: Sezt den Tag des Datums auf den letzten des Monats.</para>
        /// <para>EN: Sets the day of the <see cref="DateTime"/> to the last day in that month.</para>
        /// </summary>
        /// <param name="current">The current DateTime to be changed.</param>
        /// <returns>given <see cref="DateTime"/> with the day part set to the last day in that month.</returns>
        public static DateTime LastDayOfMonth(this DateTime current)
        {
            return current.SetDay(DateTime.DaysInMonth(current.Year, current.Month));
        }

        /// <summary>
        /// <para>DE: Rundet das <see cref="dateTime"/> Objekt auf Sekunden.</para>
        /// <para>EN: Rounds the <see cref="dateTime"/> object to seconds.</para>
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime RoundToSeconds(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
    }

    public enum Quarter
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    public enum Month
    {
        [EnumValueData(Name = "Januar")]
        January = 1,

        [EnumValueData(Name = "Februar")]
        February = 2,

        [EnumValueData(Name = "März")]
        March = 3,

        [EnumValueData(Name = "April")]
        April = 4,

        [EnumValueData(Name = "Mai")]
        May = 5,

        [EnumValueData(Name = "Juni")]
        June = 6,

        [EnumValueData(Name = "Juli")]
        July = 7,

        [EnumValueData(Name = "August")]
        August = 8,

        [EnumValueData(Name = "September")]
        September = 9,

        [EnumValueData(Name = "Oktober")]
        October = 10,

        [EnumValueData(Name = "November")]
        November = 11,

        [EnumValueData(Name = "Dezember")]
        December = 12
    }
}
