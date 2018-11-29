using SinglePageAppWebForms.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinglePageAppWebForms.Categories
{
    public partial class Edit : System.Web.UI.Page
    {
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;
            if (!IsPostBack)
            {
            LoadData();
            }
        }

        private void LoadData()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (var context = new SinglePageAppEntities())
            {
                var category= context.Categories.Where(e=>e.CategoryID==id).FirstOrDefault();
                txtTitle.Text = category.Title;
                txtDescription.Text = category.Description;
            }

        }

        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            int id = Convert.ToInt32(Request.QueryString["id"]);
                using (var context = new SinglePageAppEntities())
                {
                    var  category = context.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
                    category.Title = txtTitle.Text;
                    category.Description = txtDescription.Text;
                    context.SaveChanges();
                }

                divFormContainer.Visible = false;
                ltrMessage.Text = "تم التعديل الحمد لله";
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