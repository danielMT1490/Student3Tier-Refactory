using Student.Common.Logic.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        private readonly ILogger Log = new AdapterLog4Net(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form1()
        {
            try
            {
                int x = 3;
               var result= x / 0;
            }
            catch (Exception ex )
            {
                Log.Error(ex);
                throw;
            }
            InitializeComponent();
        }
    }
}
