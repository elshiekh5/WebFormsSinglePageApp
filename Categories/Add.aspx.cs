using SinglePageAppWebForms.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinglePageAppWebForms.Categories
{
    public partial class Add : System.Web.UI.Page
    {
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;

        }
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new SinglePageAppEntities())
                {
                    var newCategory = new Category
                    {
                        Title = txtTitle.Text,
                        Description = txtDescription.Text,
                        CreationDate = DateTime.Now
                    };
                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                }

                divFormContainer.Visible = false;
                ltrMessage.Text = "تم الاضافة الحمد لله";
                alertBox.Visible = true;
            }
            catch {
                alertBox.InnerText = "Error happend ya halawa";
                alertBox.Visible = true;

                //throw new Exception("");
            }

        }
        //------------------------------------------------------

    }
}