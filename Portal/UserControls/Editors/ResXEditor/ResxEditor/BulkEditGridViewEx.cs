using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealWorld.Grids;

namespace App_Code.Code
{
    public class BulkEditGridViewEx : BulkEditGridView
    {
        public event EventHandler<EventArgs> Saved;

        public new void Save()
        {
            foreach (GridViewRow row in DirtyRows)
                UpdateRow(row.RowIndex, false);

            DirtyRows.Clear();
            OnSaved();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Attach an event handler to the save button.
            if (false == string.IsNullOrEmpty(SaveButtonID))
            {
                Control btn = RecursiveFindControl(NamingContainer, SaveButtonID);
                if (null != btn)
                {
                    if (btn is Button)
                    {
                        ((Button)btn).Click += SaveClicked;
                    }
                    else if (btn is LinkButton)
                    {
                        ((LinkButton)btn).Click += SaveClicked;
                    }
                    else if (btn is ImageButton)
                    {
                        ((ImageButton)btn).Click += SaveClicked;
                    }

                    //add more button types here.
                }
            }
        }

        protected virtual void OnSaved()
        {
            EventHandler<EventArgs> handler = Saved;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        protected Control RecursiveFindControl(Control namingcontainer, string controlName)
        {
            Control control = namingcontainer.FindControl(controlName);
            if (control != null)
            {
                return control;
            }
            if (namingcontainer.NamingContainer != null)
            {
                return RecursiveFindControl(namingcontainer.NamingContainer, controlName);
            }
            return null;
        }

        protected virtual void SaveClicked(object sender, EventArgs e)
        {
            Save();
        }
    }
}