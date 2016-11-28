using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace templates
{
    class Progress
    {
        delegate void StatusDelegate();
        StatusDelegate StatusFormDelegate = new StatusDelegate(UpdateProgressStatus);
        StatusDelegate CloseFormDelegate = new StatusDelegate(CloseProgressForm);
        StatusDelegate SetMaxFormDelegate = new StatusDelegate(SetMaxProgressStatus);

        Thread threadProgressForm;
        Thread workThread;

        static volatile int progressStatus = 0;
        static private ProgressForm progressForm = new ProgressForm();

        public void OpenProgressForm()
        {
            progressForm.ShowDialog();
        }

        static void CloseProgressForm()
        {
            progressForm.Close();
        }

        static void UpdateProgressStatus()
        {
            progressForm.setProgress(progressStatus);
        }

        static void SetMaxProgressStatus()
        {
            progressForm.setMax(12);
        }

        public void setMax(int max)
        {
            progressStatus = 0;
            progressForm.Invoke(SetMaxFormDelegate);
        }

        public void Open()
        {
            threadProgressForm = new Thread(OpenProgressForm);
            threadProgressForm.Start();
        }

        public void setCurrent(int current)
        {
            progressStatus = current;
            progressForm.Invoke(StatusFormDelegate);
        }

        public void Close()
        {
            progressForm.Invoke(CloseFormDelegate);
            threadProgressForm.Abort();
        }
    }
}
