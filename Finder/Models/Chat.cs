using System;

namespace Finder.Models
{
    public class Chat : Model
    {
        /// <summary>
        /// O usuário que iniciou o chat
        /// </summary>
        public User FirstUser { get; set; }

        public User SecondUser { get; set; }
    }
}
