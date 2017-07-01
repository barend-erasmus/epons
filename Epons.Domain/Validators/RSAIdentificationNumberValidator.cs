using System;

namespace Epons.Domain.Validators
{
    public class RSAIdentificationNumberValidator
    {
        public bool IsValid(string identificationNumber)
        {
            if (string.IsNullOrEmpty(identificationNumber))
            {
                return false;
            }

            if (identificationNumber.Length != 13)
            {
                return false;
            }

            int controlDigit = GetControlDigit(identificationNumber);

            int lastDigit = int.Parse(identificationNumber[identificationNumber.Length - 1].ToString());

            if (lastDigit == controlDigit)
            {
                return true;
            }

            return false;
        }

        public DateTime DateOfBirth(string identificationNumber)
        {
            if (!IsValid(identificationNumber))
            {
                throw new ArgumentException("Invalid identification number");
            }

            int twoDigitYear = int.Parse(identificationNumber.Substring(0, 2));

            int year = twoDigitYear;

            if (twoDigitYear >= DateTime.Now.Year - 2000)
            {
                year += 1900;

            }else
            {
                year += 2000;
            }

            int month = int.Parse(identificationNumber.Substring(2, 2));

            int day = int.Parse(identificationNumber.Substring(4, 2));

            return new DateTime(year, month, day);
        }

        public bool IsMale(string identificationNumber)
        {
            if (!IsValid(identificationNumber))
            {
                throw new ArgumentException("Invalid identification number");
            }

            return int.Parse(identificationNumber.Substring(6, 1)) >= 5 && int.Parse(identificationNumber.Substring(6, 1)) <= 9;
        }

        public bool IsFemale(string identificationNumber)
        {
            if (!IsValid(identificationNumber))
            {
                throw new ArgumentException("Invalid identification number");
            }

            return int.Parse(identificationNumber.Substring(6, 1)) >= 0 && int.Parse(identificationNumber.Substring(6, 1)) <= 4;
        }

        public int GetControlDigit(string identificationNumber)
        {
            int d = -1;
            try
            {
                int a = 0;
                for (int i = 0; i < 6; i++)
                {
                    a += int.Parse(identificationNumber[2 * i].ToString());
                }
                int b = 0;
                for (int i = 0; i < 6; i++)
                {
                    b = b * 10 + int.Parse(identificationNumber[2 * i + 1].ToString());
                }
                b *= 2;
                int c = 0;
                do
                {
                    c += b % 10;
                    b = b / 10;
                }
                while (b > 0);
                c += a;
                d = 10 - (c % 10);
                if (d == 10) d = 0;
            }
            catch
            {

            }
            return d;
        }
    }
}
