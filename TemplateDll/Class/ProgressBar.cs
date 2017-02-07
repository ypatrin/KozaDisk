using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace templates
{
    class Progress
    {
        private static Progress instance;

        delegate void StatusDelegate();
        StatusDelegate StatusFormDelegate = new StatusDelegate(UpdateProgressStatus);
        StatusDelegate CloseFormDelegate = new StatusDelegate(CloseProgressForm);
        StatusDelegate SetMaxFormDelegate = new StatusDelegate(SetMaxProgressStatus);

        Thread threadProgressForm;

        static volatile int progressStatus = 0;
        static volatile int progressStatusMax = 0;
        static private ProgressForm progressForm = new ProgressForm();

        private Progress()
        { }

        public static Progress getInstance()
        {
            if (instance == null)
                instance = new Progress();
            return instance;
        }

        public void OpenProgressForm()
        {
            progressForm.Visible = false;
            progressForm.ShowDialog();
        }

        static void CloseProgressForm()
        {
            progressForm.Close();
        }

        static void UpdateProgressStatus()
        {
            while (progressForm.IsHandleCreated == false)
            {
                
            }

            progressForm.setProgress(progressStatus);
        }

        static void SetMaxProgressStatus()
        {
            while (progressForm.IsHandleCreated == false)
            {
                //Application.DoEvents();
            }

            progressForm.setMax(progressStatusMax);
        }

        public void setMax(int max)
        {
            while (progressForm.IsHandleCreated == false)
            {
                //Application.DoEvents();
            }

            progressStatusMax = max;
            progressForm.Invoke(SetMaxFormDelegate);
        }

        public void Open()
        {
            threadProgressForm = new Thread(OpenProgressForm);
            threadProgressForm.Start();
        }

        public void setCurrent(int current)
        {
            while (progressForm.IsHandleCreated == false)
            {
                //Application.DoEvents();
            }

            progressStatus = current;
            progressForm.Invoke(StatusFormDelegate);
        }

        public void Close()
        {
            try
            {
                progressForm.Invoke(CloseFormDelegate);
                //threadProgressForm.Abort();
                threadProgressForm.Join();
            }
            catch (ThreadAbortException tae) { }
            catch (Exception e) { }
        }
    }
}
