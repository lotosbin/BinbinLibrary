using System;

namespace Binbin.Linq.Dynamic
{
    public sealed class ParseException : Exception
    {
        int position;

        public ParseException(string message, int position)
                : base(message)
        {
            this.position = position;
        }

        public int Position
        {
            get { return this.position; }
        }

        public override string ToString()
        {
            return string.Format(Res.ParseExceptionFormat, this.Message, this.position);
        }
    }
}