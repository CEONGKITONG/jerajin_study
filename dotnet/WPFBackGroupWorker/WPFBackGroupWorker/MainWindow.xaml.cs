using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFBackGroupWorker
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        private BackgroundWorker myThread;

        int sum = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // 백그라운드 워크 초기화
            // 작업의 진행율이 바뀔대 ProgressChanged 이벤트 발생 여부
            // 작업쉬로 가능 여부 true로 설정
            myThread = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            // 해야할 작업을 실행할 메소드 정의
            myThread.DoWork += myThread_DoWork;

            // UI 쪽에 진행사항을 보여주기 위해
            // WorkReportsProgress 속성값이 true 일때만 이벤트 발생 (myThread.ReportProgress() 로 호출하여 이벤트 발생 처리)
            myThread.ProgressChanged += myThread_ProgressChanged;

            // 작업이 완료되었을 때 실행할 콜백메소드 정의
            myThread.RunWorkerCompleted += myThread_RunWorkerCompleted;

            MessageBox.Show("Worker 초기화");

        }


        // 백그라운드 워크가 실행하는 작업
        // DoWork 이벤트 처리 메소드에서 lstNumber,.Items.Add(i) 와 같은 코드를
        // 직접 실행시키면 "InvalidOperationException" 오류 발생 ( UI 컨트롤에 접근할 수 없기 때문에 UI 값을 파라미터로 받아야한다)
        private void myThread_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = (int)e.Argument;

            for (int i=1; i <= count; i++)
            {
                if (myThread.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Thread.Sleep(100);
                    // UI 컨트롤을 직접 접근할 수 없기 때문에 Dispatcher 를 통해서 UI 컨트롤에 접근해야한다.
                    //  실행되는 동안에 Blocking 되어 다른곳에서는 사용할 수 없다.
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                                (ThreadStart)delegate ()
                                                {
                                                    if (i % 2 == 0)
                                                    {
                                                        sum += i;
                                                        e.Result = sum;
                                                        lstNumber.Items.Add(i);
                                                    }
                                                }
                         
                                                );
                    myThread.ReportProgress(i);     // 프로그래스바를 변경하도록 반영 (ProcessChanged 이벤트가 발생하여 UI를 업데이트하는 것이 가능)
                }
            }

        }

        // 작업의 진행율이 바뀔 때 발생, ProgressBar에 변경사항을 출력
        // 대체로 현재의 진행상태롤 보여주는 코드 여기에 작성
        private void myThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        // 작업이 완료
        private void myThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) MessageBox.Show("작업 취소..... ");
            else if (e.Error != null) MessageBox.Show("에러발생 .... " + e.Error);
            else
            {
                lblSum.Content = ((int)e.Result).ToString();
                MessageBox.Show("작업 완료!!!!");
            }
            
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int num;

            if (!int.TryParse(txtNumber.Text, out num))
            {
                MessageBox.Show("숫자를 입력하세요...!");
                return;
            }

            progressBar.Maximum = num;
            lstNumber.Items.Clear();
            myThread.RunWorkerAsync(num);  // private void myThread_DoWork(object sender, DoWorkEventArgs e) 에 넘어감
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            myThread.CancelAsync();
        }
    }
}
