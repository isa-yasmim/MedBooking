using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBooking
{
    internal class Utils
    {
        public static Dictionary<int, string> getSlot()
        {
            Dictionary<int, string> slot = new Dictionary<int, string>();
            slot.Add(1, "08:00");
            slot.Add(2, "08:30");
            slot.Add(3, "09:00");
            slot.Add(4, "09:30");
            slot.Add(5, "10:00");
            slot.Add(6, "10:30");
            slot.Add(7, "11:00");
            slot.Add(8, "14:00");
            slot.Add(9, "14:30");
            slot.Add(10, "15:00");
            slot.Add(11, "15:30");
            slot.Add(12, "16:00");

            return slot;
        }

        public string horaSlot(int key)
        {
            Dictionary<int, string> slotTimes = Utils.getSlot();

            if (slotTimes.ContainsKey(key))
            {
                return slotTimes[key];
            }
            else
            {
                return "00:00"; // Default value when the key is not found
            }
        }

    }
}
