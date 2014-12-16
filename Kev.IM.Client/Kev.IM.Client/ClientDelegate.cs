using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kev.IM.Client
{
    public delegate void CallBack();
    public delegate void CallBackWithObject(object obj);

    //public class ClientDelegate
    //{
    //    private static ClientDelegate _delegate;

    //    private CallBackWithObject callBack_showForm;
    //    private CallBackWithObject callBack_hideForm;

    //    private ClientDelegate() { }

    //    public static ClientDelegate GetInstance()
    //    {
    //        if (_delegate == null)
    //            _delegate = new ClientDelegate();

    //        return _delegate;
    //    }

    //    public void ShowMainForm()
    //    {
    //        MainForm form = KevRegister.Get<MainForm>(ClientItemsPrimaryKey.Form_Main);
    //        if (form != null)
    //            callBack_showForm(form);
    //    }

    //    public void HideMainForm()
    //    {
    //        MainForm form = KevRegister.Get<MainForm>(ClientItemsPrimaryKey.Form_Main);
    //        if (form != null)
    //            callBack_hideForm(form);
    //    }

    //    public void ShowHomeForm()
    //    {

    //    }

    //    public void HideHomeForm()
    //    {

    //    }

    //    private void ShowFormInMainThread(object obj)
    //    {
    //        Form form = obj as Form;
    //        if (form != null)
    //            form.Show();
    //    }

    //    private void HideFormInMainThread(object obj)
    //    {
    //        Form form = obj as Form;
    //        if (form != null)
    //            form.Hide();
    //    }
    //}
}
