using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracks.Model
{
    public class Meet
    {
        private readonly int _cookingTime;

        public static Meet CreateMeet()
        {
            return new Meet(MeetType.None);
        }

        public static Meet CreateMeet(int cookingTime)
        {
            if (cookingTime < 10 && cookingTime >= 5)
            {
                return new Meet(MeetType.Medium, cookingTime);
            }
            if (cookingTime >= 10)
            {
                return new Meet(MeetType.Full, cookingTime);
            }

            if (cookingTime > 0)
            {
                return new Meet(MeetType.Rare, cookingTime);
            }
            throw new ArgumentException();
        }
        private Meet(MeetType type, int cookingTime = 0)
        {
            _cookingTime = cookingTime;
            Type = type;
        }
        public MeetType Type { get;}
    }
}
