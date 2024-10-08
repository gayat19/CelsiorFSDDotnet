﻿using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{
    
    public class CannotAddWithNoImagesException : Exception
    {
        
        public CannotAddWithNoImagesException()
        {
            msg = "Cannot add a images object with no images";
        }
        string msg;
        public override string Message => msg;

    }
}