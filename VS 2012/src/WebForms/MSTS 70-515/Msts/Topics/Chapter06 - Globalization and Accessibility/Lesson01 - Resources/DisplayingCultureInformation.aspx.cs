using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter06___Globalization_and_Accessibility.Lesson01___Resources
{
    public partial class DisplayingCultureInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<CultureInfo> gv_GetData()
        {

            return CultureInfo.GetCultures(CultureTypes.AllCultures).AsQueryable();
        }
    }
}