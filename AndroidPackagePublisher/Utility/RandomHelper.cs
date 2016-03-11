using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidPackagePublisher.Utility
{
    public class RandomHelper
    {
        public static string PasswordCreatorZiMu(Random pwdRand, int length)
        {
            string pwd = string.Empty;
            for (int i = 0; i < length; i++)
            {
                pwd += ((char)pwdRand.Next(65, 90)).ToString().ToLower();

            }
            return pwd;
        }

        public static string GetPackageName()
        {
            Random rd = new Random();
            int middle = rd.Next(4, 9);
            int last = rd.Next(4, 9);

            return "com." + PasswordCreatorZiMu(rd, middle) + "." + PasswordCreatorZiMu(rd, last);
        }
    }
}
