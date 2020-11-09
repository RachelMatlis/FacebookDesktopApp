using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.Logic
{
    public class ListBoxApp<T>
    {
        public static void LoadListBox(ListBox i_ListBox, IEnumerable<T> i_ObjectList, string i_DisplayMember)
        {
            i_ListBox.Invoke(new Action(() => i_ListBox.Items.Clear()));
            i_ListBox.Invoke(new Action(() => i_ListBox.DisplayMember = i_DisplayMember));

            if (i_ObjectList.ToList().Count != 0)
            {
                foreach (T item in i_ObjectList)
                {
                    i_ListBox.Invoke(new Action(() => i_ListBox.Items.Add(item)));
                }
            }
            else
            {
                i_ListBox.Invoke(new Action(() => i_ListBox.Items.Add("No Information")));
            }
        }
    }
}