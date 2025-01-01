using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Image1.ImageUrl = "";
                Label1.Text = "Price will be displayed";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = DropDownList1.SelectedValue;

            switch (selectedProduct)
            {
                case "1":
                    Image1.ImageUrl = "C:\dot net training\ASP\Assignment\WebApplication1\WebApplication1\images\Audi.jpg";
                    break;

                case "2":
                    Image1.ImageUrl = "C:\dot net training\ASP\Assignment\WebApplication1\WebApplication1\images\Bugatti.jpg";
                    break;

                case "3":
                    Image1.ImageUrl = "C:\dot net training\ASP\Assignment\WebApplication1\WebApplication1\images\MercedesBenz.jpg";
                    break;

                default:
                    Image1.ImageUrl = "";
                    Label1.Text = "Please select a product";
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string selectedprod = DropDownList1.SelectedValue;
            string price = " ";
            switch (selectedprod)
            {
                case "1":
                    price = "150 rupees";
                    break;
                case "2":
                    price = "245 rupees";
                    break;
                case "3":
                    price = "315 rupees";
                    break;
                default:
                    price = "Please select product";
                    break;


            }
            Label1.Text = "price:" + price;
        }
    }
}