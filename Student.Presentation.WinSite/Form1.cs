using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using Student.Common.Logic.UtilsConfig;
using Student.DataAccess.Dao.DAO;
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
        public static readonly ILogger Log = new AdapterLog4Net(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        public Form1()
        {
            try
            {
              
                StudentSql<Alumno> stu = new StudentSql<Alumno>();
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
