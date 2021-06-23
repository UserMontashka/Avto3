using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avto.Models;

namespace Avto.Controllers

{
    public class UserController
    {
        public Core db = new Core();
        public Users usersobj;
        public Users usersobj1;
        public bool CheckLogin(string login)
        {
            if (login != "")
            {
                usersobj = db.context.Users.Where(x => x.login == login).FirstOrDefault();
                if (usersobj == null)
                {

                    return false;
                }
                else
                {

                    return true;
                }
            }
            else
            {
                return false;
            }

        }
        public bool CheckPassword(string password)
        {
            if (password != "")
            {
                usersobj1 = db.context.Users.Where(x => x.password == password).FirstOrDefault();
                if (usersobj1 == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool TextPaspportNumber(string text)
        {
            char[] dostup = {'1','2','3','4','5','6','7','8','9','0'};
            int y=0;
            foreach (char item in text)
            {

                bool ok = false;
                for (int i = 0; i < dostup.Length; i++)
                {
                    if (item == dostup[i])
                    {
                        ok = true;
                    }
                }
                if (!ok)
                {
                    return false;
                }
                y++;
            }
            if (y == 10)
                return true;
            else
                return false;
        }
        public bool TextUdostoverenie(string text)
        {
            char[] dostup = {'1','2','3','4','5','6','7','8','9','0','-'};
            char[] prav = new char[9];
            int u = 0;
            foreach (char item in text)
            {
                prav[u] = item;
                bool ok = false;
                for (int i = 0; i < dostup.Length; i++)
                {
                    if (item == dostup[i])
                    {
                        ok = true;
                    }
                }
                if (!ok)
                {
                    return false;
                }
                u =u+1;
            }
            if (prav[6] == '-' && u ==9)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool TextGosNumber(string text)
        {
            char[] dostupSymbol = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0','-',
                'А','В','Е','К','М','Н','О','Р','С','Т','У','Х',
                'A','B','E','K','M','H','O','P','C','T','Y','X'};
            char[] dostupNumber = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            char[] prav = new char[9];
            int y = 0;
            int count = 0;
            foreach (char item in text)
            {
                prav[y] = item;
                bool ok = false;
                for (int i = 0; i < dostupSymbol.Length; i++)
                {
                    if (item == dostupSymbol[i])
                    {
                        ok = true;
                    }
                }
                if (!ok)
                {
                    return false;
                }
                y++;
            }
            
            for (int i = 0; i < dostupNumber.Length; i++)
            {
                if (prav[1] == dostupNumber[i])
                {
                    count++;
                }
                if (prav[2] == dostupNumber[i])
                {
                    count++;
                }
                if (prav[3] == dostupNumber[i])
                {
                    count++;
                }
                if (prav[7] == dostupNumber[i])
                {
                    count++;
                }
                if (prav[8] == dostupNumber[i])
                {
                    count++;
                }
            }
            if (y == 9 && prav[6] =='-'&& count==5)
                return true;
            else
                return false;


        }

    }
}
