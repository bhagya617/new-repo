using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

namespace WebApplication1

{

    public partial class Validator : System.Web.UI.Page

    {

        protected void Page_Load(object sender, EventArgs e)

        {

        }

        protected void Button1_Click(object sender, EventArgs e)

        {

            if (Page.IsValid)

            {

                Response.Write("<script>alert('All fields are correct')</script>");

            }

            else

            {

                Response.Write("<script>alert('please correct the errors in the form')</script>");

            }

        }

    }

}
