﻿using System;
using System.Collections.Generic;
using System.Text;

namespace 動物練習
{
    class AnimalFactory
    {
        public static Animal CreateAnimal(string animalCategory, string animalName,int shoutNumber)
        {
            Animal result=null;
            switch (animalCategory)
            {
                case "貓":
                    result = new Cat(animalName);
                    break;
                case "狗":
                    result = new Dog(animalName);
                    break;
                case "羊":
                    result = new Sheep(animalName);
                    break;
            }
            result.ShoutNum = shoutNumber;
                    
            return result;
        }
    }
}
