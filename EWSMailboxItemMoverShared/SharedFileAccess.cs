using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;


namespace EWSMailboxItemMover
{
    class JsonUserFile
    {
        public void loadJsonUserFile()
        {
            using (StreamReader r = new StreamReader("mailbox.json"))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Console.WriteLine("{0} {1}", item.temp, item.vcc);
                }
            }
        }
    }
}
