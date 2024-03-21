using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public static class InventoryDB
    {
        private static readonly string Path = @"Z:\Documents\C# App dev\Lab6\grocery_inventory_items.txt";

        public static List<InventoryItem> GetItems()
        {
            List<InventoryItem> items = new List <InventoryItem>();


            using (StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                string row;
                while ((row = textIn.ReadLine()) != null)
                {
                    string[] columns = row.Split('|');


                    if (columns.Length == 3)
                    {
                        InventoryItem item = new InventoryItem
                        {
                            ItemNo = Convert.ToInt32(columns[0]),
                            Description = columns[1],
                            Price = Convert.ToDecimal(columns[2])
                        };
                        items.Add(item);
                    }
                }
            }
            return items;
        }


        // SaveItems method
        public static void SaveItems(List<InventoryItem> items)
        {
            using (StreamWriter textOut = new StreamWriter(new FileStream(Path, FileMode.Append, FileAccess.Write)))
            {
                foreach (InventoryItem item in items)
                {
                    textOut.Write(item.ItemNo + " | ");
                    textOut.Write(item.Description + " | ");
                    textOut.WriteLine(item.Price);
                }
            }
        }

        //delete item method    
        public static void DeleteItem(int index)
        {
            List<InventoryItem> items = GetItems();
            items.RemoveAt(index);
            File.Delete(Path);
            SaveItems(items);
        }
    }
}
