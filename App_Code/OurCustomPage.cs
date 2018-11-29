using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinglePageAppWebForms.App_Code
{
    public class OurCustomPage : System.Web.UI.Page
    {

        //------------------------------------------------------
        //OnLoadComplete
        //------------------------------------------------------
        protected override void OnPreLoad(EventArgs e)
        {

            ReduceUsingViewState();
            CheckPageOperations();
            base.OnPreLoad(e);
        }

        //------------------------------------------------------



        private void ReduceUsingViewState()
        {
            int ViewStateControls = 0;
            foreach (Control c in this.Page.Controls)
            {
                //---------------------------------
                if (c is WebControl)
                {
                    c.EnableViewState = false;
                    Type s = c.GetType();
                }
                //---------------------------------
                foreach (Control item in c.Controls)
                {
                    if (item is WebControl && (item is DropDownList == false))
                    {
                        item.EnableViewState = false;
                    }
                    else
                    {
                        ++ViewStateControls;
                    }

                }
            }
            //---------------------------------
            //if the is no any control that needs to viewstate then set EnableViewState of the page to false else set to true 
            if (ViewStateControls == 0)
            {
                this.EnableViewState = false;
            }
            {
                this.EnableViewState = true;
            }
            //---------------------------------
        }

        private void CheckPageOperations()
        {

            string operation = Request.QueryString["operation"];
            if (!IsPostBack)
            {

                switch (operation)
                {
                    case "delete":
                        Delete();
                        break;
                    default:
                        break;
                }
            }
        }

        protected virtual void Delete()
        {

        }

    }
}