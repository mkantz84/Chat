﻿using System;
using System.Drawing;

namespace Classes
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public Color UserColor { get; set; }                

        public override string ToString()
        {
            return NickName;
        }        
    }    
}
