﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class names
    {
        public static List<string> chnConsonantList = new List<string> {
            "b", "p", "m", "f", "d", "t", "n", "l",
            "g", "k", "h", "j", "q", "x",
            "zh", "ch", "sh", "r", "z", "c", "s", "y", "w" };
        public static List<string> chnVowelList = new List<string> {
            "a", "o", "e", "i", "u", "v",
            "ao", "ai", "an", "ang",
            "ou", "ong",
            "ei", "en", "eng", "er",
            "ia", "iao", "ian", "iang", "ie", "iong", "iou", "in", "ing", "iu",
            "ua", "uai", "uan", "uang", "ue", "uei", "uen", "ueng", "ui", "uo", "un",
            "van", "ve", "vn"};

        public static bool chnLastName(string LastName)
        {
            bool chnNameFlag = false;

            string lowerCase = LastName.ToLower();
            char[] split = lowerCase.ToCharArray();

            // 先把声母剔除掉，如果剩下的是韵母，那就是汉语名
            if (chnConsonantList.Exists(o => o == split[0].ToString()))
            {
                string restName = "";
                if (split.Count() == 1)
                {
                    chnNameFlag = false;
                }
                else
                {
                    if ((split[0] == 's' || split[0] == 'c' || split[0] == 'z') && split[1] == 'h')
                    {
                        if (split.Count() == 2)
                        {
                            chnNameFlag = false;
                        }
                        else
                        {
                            for (int i = 2; i < split.Count(); i++)
                            {
                                restName += split[i].ToString();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i < split.Count(); i++)
                        {
                            restName += split[i].ToString();
                        }
                    }
                }
                if (chnVowelList.Exists(o => o == restName))
                {
                    chnNameFlag = true;
                }
            }
            // 如果是韵母开头的，主要是针对“艾”， “鳌”等等这类姓
            else if (chnVowelList.Exists(o => o == lowerCase))
            {
                chnNameFlag = true;
            }

            return chnNameFlag;
        }

        public static string processName(string name)
        {
            string initialed = "";
            string[] splitName = name.Split(' ');

            string lastName = splitName[splitName.Count() - 1];
            if (lastName == "")
            {
                return "(No-last-Name)";
            }
            if (!chnLastName(lastName))
            {
                initialed += splitName[splitName.Count() - 1];
                initialed += ", ";
                initialed += splitName[0].ToCharArray()[0];
                initialed += ". ";
            }
            else
            {
                initialed += splitName[splitName.Count() - 1];
                initialed += ", ";
                for (int i = 0; i < splitName.Count() - 1; i++)
                {
                    initialed += splitName[i];
                    initialed += " ";
                }
            }
            return initialed;
        }
    }
}
