using System;
using System.Text.RegularExpressions;

public partial class validator : System.Web.UI.Page
{
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        string familyName = txtFamilyName.Text.Trim();
        string address = txtAddress.Text.Trim();
        string city = txtCity.Text.Trim();
        string zipCode = txtZipCode.Text.Trim();
        string phone = txtPhone.Text.Trim();
        string email = txtEmail.Text.Trim();

        string errorMessage = "";

        // Name validation
        if (name == familyName)
        {
            errorMessage += "Name and Family Name must be different.<br />";
        }

        // Address validation
        if (address.Length < 2)
        {
            errorMessage += "Address must contain at least 2 characters.<br />";
        }

        // City validation
        if (city.Length < 2)
        {
            errorMessage += "City must contain at least 2 characters.<br />";
        }

        // Zip Code validation
        if (!Regex.IsMatch(zipCode, @"^\d{5}$"))
        {
            errorMessage += "Zip Code must be 5 digits.<br />";
        }

        // Phone validation
        if (!Regex.IsMatch(phone, @"^\d{2,3}-\d{7}$"))
        {
            errorMessage += "Phone must follow the format XX-XXXXXXX or XXX-XXXXXXX.<br />";
        }

        // Email validation
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            errorMessage += "Email is not valid.<br />";
        }

        if (string.IsNullOrEmpty(errorMessage))
        {
            lblError.Text = "All validations passed.";
        }
        else
        {
            lblError.Text = errorMessage;
        }
    }
}