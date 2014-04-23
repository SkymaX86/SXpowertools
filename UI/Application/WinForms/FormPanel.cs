using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SXpowertools.UI.Application.WinForms
{
    public class FormPanel
    {
        // ** Fügt dem Panel das Formular hinzu
        //Beispiel : newForm = CFormPanel.AddForm<FormInPanel>( panelForm );
        // muss vom Type Form sein und muss einen Parameterlosen construktor besitzen
        static public T AddForm<T>(Panel panelForm) where T : Form, new()
        {
            FormPanel.CloseForm(panelForm);

            T form = new T();

            panelForm.BorderStyle = BorderStyle.None;
            i_InsertFormToPanel(panelForm, form);

            return form;
        }

        // ** Fügt dem Panel das Formular hinzu
        // Beispiel : CFormPanel.AddForm( panelForm, oneForm );
        static public void AddForm(Panel panelForm, Form form)
        {
            if (form == null)
                return;

            FormPanel.CloseForm(panelForm);

            panelForm.BorderStyle = BorderStyle.None;
            i_InsertFormToPanel(panelForm, form);
        }

        // ** Schließt alle Fenster in dem Panel
        //
        static public void CloseForm(Panel panelForm)
        {
            if (panelForm == null)
                return;

            if (panelForm.Controls.Count > 0)
            {
                foreach (Control cc in panelForm.Controls)
                {
                    if (cc is Form)
                    {
                        (cc as Form).Close();
                    }//if

                }//foreach
            }//if
        }

        // ** Bindet das Form in das Panel, und zeigt es an
        //
        static private void i_InsertFormToPanel(Panel panelForm, Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panelForm.Controls.Add(form);
            form.Show();
        }
    }
}
